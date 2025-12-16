using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;
using Marketum.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Marketum.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepo;
        private readonly Mock<IOrderItemRepository> _mockOrderItemRepo;
        private readonly Mock<IProductRepository> _mockProductRepo;
        private readonly Mock<IClientRepository> _mockClientRepo;
        private readonly Mock<ICampaignService> _mockCampaignService;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _mockOrderRepo = new Mock<IOrderRepository>();
            _mockOrderItemRepo = new Mock<IOrderItemRepository>();
            _mockProductRepo = new Mock<IProductRepository>();
            _mockClientRepo = new Mock<IClientRepository>();
            _mockCampaignService = new Mock<ICampaignService>();

            _orderService = new OrderService(
                _mockOrderRepo.Object,
                _mockOrderItemRepo.Object,
                _mockProductRepo.Object,
                _mockClientRepo.Object,
                _mockCampaignService.Object
            );
        }

        [Fact]
        public void CreateOrder_WithValidData_ShouldCreateOrderSuccessfully()
        {
            // Arrange
            int clientId = 1;
            int employeeId = 1;
            int productId = 1;
            int initialStock = 100;
            int orderQuantity = 5;
            int expectedFinalStock = 95;

            var client = new Client
            {
                Id = clientId,
                Name = "João Silva",
                Email = "joao@email.com"
            };

            var product = new Product
            {
                Id = productId,
                Name = "Produto Teste",
                Price = 10.50m,
                Stock = initialStock,
                CategoryId = 1,
                BrandId = 1
            };

            var expectedOrder = new Order
            {
                Id = 1,
                CustomerId = clientId,
                EmployeeId = employeeId,
                PaymentMethod = PaymentMethod.CreditCard,
                Status = OrderStatus.Created
            };

            var orderItems = new List<(int productId, int quantity)>
            {
                (productId, orderQuantity)
            };

            // Setup mocks
            _mockClientRepo.Setup(r => r.GetById(clientId))
                          .Returns(client);

            _mockProductRepo.Setup(r => r.GetById(productId))
                           .Returns(product);

            _mockOrderRepo.Setup(r => r.Add(It.IsAny<Order>()))
                         .Returns(expectedOrder);

            _mockCampaignService.Setup(s => s.GetActiveCampaignForCategory(It.IsAny<int>()))
                              .Returns((Campaign?)null);

            _mockCampaignService.Setup(s => s.GetActiveGlobalCampaign())
                              .Returns((Campaign?)null);

            // Act
            var result = _orderService.CreateOrder(
                clientId,
                employeeId,
                UserRole.Employee,
                PaymentMethod.CreditCard,
                orderItems
            );

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOrder.Id, result.Id);
            Assert.Equal(clientId, result.CustomerId);
            Assert.Equal(employeeId, result.EmployeeId);
            Assert.Equal(OrderStatus.Created, result.Status);

            // Verificar se o stock foi decrementado corretamente
            Assert.Equal(expectedFinalStock, product.Stock);

            // Verificar se os métodos dos repositórios foram chamados
            _mockProductRepo.Verify(r => r.Update(product), Times.Once);
            _mockOrderRepo.Verify(r => r.Add(It.IsAny<Order>()), Times.Once);
            _mockOrderItemRepo.Verify(r => r.AddItems(expectedOrder.Id, It.IsAny<List<OrderItem>>()), Times.Once);
        }

        [Fact]
        public void CreateOrder_WithNonExistentClient_ShouldThrowNotFoundException()
        {
            // Arrange
            int clientId = 999;
            _mockClientRepo.Setup(r => r.GetById(clientId))
                          .Returns((Client?)null);

            var orderItems = new List<(int productId, int quantity)>
            {
                (1, 5)
            };

            // Act & Assert
            var exception = Assert.Throws<NotFoundException>(() =>
                _orderService.CreateOrder(
                    clientId,
                    1,
                    UserRole.Employee,
                    PaymentMethod.CreditCard,
                    orderItems
                ));

            Assert.Equal("Cliente não encontrado.", exception.Message);
            _mockOrderRepo.Verify(r => r.Add(It.IsAny<Order>()), Times.Never);
        }

        [Fact]
        public void CreateOrder_WithNonExistentProduct_ShouldThrowNotFoundException()
        {
            // Arrange
            int clientId = 1;
            int productId = 999;

            var client = new Client { Id = clientId, Name = "João Silva" };

            _mockClientRepo.Setup(r => r.GetById(clientId))
                          .Returns(client);

            _mockProductRepo.Setup(r => r.GetById(productId))
                           .Returns((Product?)null);

            var orderItems = new List<(int productId, int quantity)>
            {
                (productId, 5)
            };

            // Act & Assert
            var exception = Assert.Throws<NotFoundException>(() =>
                _orderService.CreateOrder(
                    clientId,
                    1,
                    UserRole.Employee,
                    PaymentMethod.CreditCard,
                    orderItems
                ));

            Assert.Equal($"Produto {productId} não encontrado.", exception.Message);
            _mockOrderRepo.Verify(r => r.Add(It.IsAny<Order>()), Times.Never);
        }

        [Fact]
        public void CreateOrder_WithInsufficientStock_ShouldThrowValidationException()
        {
            // Arrange
            int clientId = 1;
            int productId = 1;
            int availableStock = 3;
            int requestedQuantity = 5;

            var client = new Client { Id = clientId, Name = "João Silva" };
            var product = new Product
            {
                Id = productId,
                Name = "Produto Teste",
                Stock = availableStock,
                Price = 10.50m
            };

            _mockClientRepo.Setup(r => r.GetById(clientId))
                          .Returns(client);

            _mockProductRepo.Setup(r => r.GetById(productId))
                           .Returns(product);

            var orderItems = new List<(int productId, int quantity)>
            {
                (productId, requestedQuantity)
            };

            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() =>
                _orderService.CreateOrder(
                    clientId,
                    1,
                    UserRole.Employee,
                    PaymentMethod.CreditCard,
                    orderItems
                ));

            Assert.Equal($"Stock insuficiente para '{product.Name}'.", exception.Message);
            _mockOrderRepo.Verify(r => r.Add(It.IsAny<Order>()), Times.Never);
        }

        [Fact]
        public void CreateOrder_WithCashPaymentAndNonAdminUser_ShouldThrowValidationException()
        {
            // Arrange
            int clientId = 1;
            var client = new Client { Id = clientId, Name = "João Silva" };

            _mockClientRepo.Setup(r => r.GetById(clientId))
                          .Returns(client);

            var orderItems = new List<(int productId, int quantity)>
            {
                (1, 5)
            };

            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() =>
                _orderService.CreateOrder(
                    clientId,
                    1,
                    UserRole.Employee, // Não é Admin
                    PaymentMethod.Cash,
                    orderItems
                ));

            Assert.Equal("Apenas administradores podem usar 'Cash'.", exception.Message);
            _mockOrderRepo.Verify(r => r.Add(It.IsAny<Order>()), Times.Never);
        }

        [Fact]
        public void CreateOrder_WithEmptyItems_ShouldThrowValidationException()
        {
            // Arrange
            int clientId = 1;
            var client = new Client { Id = clientId, Name = "João Silva" };

            _mockClientRepo.Setup(r => r.GetById(clientId))
                          .Returns(client);

            var emptyOrderItems = new List<(int productId, int quantity)>();

            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() =>
                _orderService.CreateOrder(
                    clientId,
                    1,
                    UserRole.Employee,
                    PaymentMethod.CreditCard,
                    emptyOrderItems
                ));

            Assert.Equal("A encomenda deve conter produtos.", exception.Message);
            _mockOrderRepo.Verify(r => r.Add(It.IsAny<Order>()), Times.Never);
        }

        [Fact]
        public void CreateOrder_WithMultipleProducts_ShouldUpdateAllProductsStock()
        {
            // Arrange
            int clientId = 1;
            int employeeId = 1;

            var client = new Client { Id = clientId, Name = "João Silva" };

            var product1 = new Product { Id = 1, Name = "Produto 1", Price = 10m, Stock = 50, CategoryId = 1, BrandId = 1 };
            var product2 = new Product { Id = 2, Name = "Produto 2", Price = 20m, Stock = 30, CategoryId = 1, BrandId = 1 };

            var expectedOrder = new Order { Id = 1, CustomerId = clientId, EmployeeId = employeeId };

            var orderItems = new List<(int productId, int quantity)>
            {
                (1, 5), // Produto 1: 50 - 5 = 45
                (2, 3)  // Produto 2: 30 - 3 = 27
            };

            // Setup mocks
            _mockClientRepo.Setup(r => r.GetById(clientId)).Returns(client);
            _mockProductRepo.Setup(r => r.GetById(1)).Returns(product1);
            _mockProductRepo.Setup(r => r.GetById(2)).Returns(product2);
            _mockOrderRepo.Setup(r => r.Add(It.IsAny<Order>())).Returns(expectedOrder);
            _mockCampaignService.Setup(s => s.GetActiveCampaignForCategory(It.IsAny<int>())).Returns((Campaign?)null);
            _mockCampaignService.Setup(s => s.GetActiveGlobalCampaign()).Returns((Campaign?)null);

            // Act
            var result = _orderService.CreateOrder(clientId, employeeId, UserRole.Employee, PaymentMethod.CreditCard, orderItems);

            // Assert
            Assert.Equal(45, product1.Stock);
            Assert.Equal(27, product2.Stock);
            _mockProductRepo.Verify(r => r.Update(product1), Times.Once);
            _mockProductRepo.Verify(r => r.Update(product2), Times.Once);
            _mockOrderRepo.Verify(r => r.Add(It.IsAny<Order>()), Times.Once);
        }
    }
}