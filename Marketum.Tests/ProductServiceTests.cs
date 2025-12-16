using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;
using Marketum.Services;
using Moq;
using Xunit;

namespace Marketum.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockRepository.Object);
        }

        [Theory]
        [InlineData(0, "O preço tem de ser maior que zero.")]
        [InlineData(-1, "O preço tem de ser maior que zero.")]
        [InlineData(-10.50, "O preço tem de ser maior que zero.")]
        public void AddProduct_WithInvalidPrice_ShouldThrowValidationException(decimal price, string expectedMessage)
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<ValidationException>(() =>
                _productService.AddProduct("Produto Teste", 1, price, 10, 1));

            Assert.Equal(expectedMessage, exception.Message);
            _mockRepository.Verify(r => r.Add(It.IsAny<Product>()), Times.Never);
        }

        [Theory]
        [InlineData(-1, "O stock não pode ser negativo.")]
        [InlineData(-5, "O stock não pode ser negativo.")]
        [InlineData(-100, "O stock não pode ser negativo.")]
        public void AddProduct_WithNegativeStock_ShouldThrowValidationException(int stock, string expectedMessage)
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<ValidationException>(() =>
                _productService.AddProduct("Produto Teste", 1, 10.50m, stock, 1));

            Assert.Equal(expectedMessage, exception.Message);
            _mockRepository.Verify(r => r.Add(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public void AddProduct_WithValidData_ShouldCallRepository()
        {
            // Arrange
            var expectedProduct = new Product
            {
                Id = 1,
                Name = "Produto Teste",
                BrandId = 1,
                Price = 10.50m,
                Stock = 100,
                CategoryId = 1
            };

            _mockRepository.Setup(r => r.Add(It.IsAny<Product>()))
                          .Returns(expectedProduct);

            // Act
            var result = _productService.AddProduct("Produto Teste", 1, 10.50m, 100, 1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedProduct.Name, result.Name);
            Assert.Equal(expectedProduct.Price, result.Price);
            _mockRepository.Verify(r => r.Add(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void UpdateStock_WithPositiveAmount_ShouldAddToStock()
        {
            // Arrange
            int productId = 1;
            int initialStock = 50;
            int amountToAdd = 25;
            int expectedFinalStock = 75;

            var product = new Product
            {
                Id = productId,
                Name = "Produto Teste",
                Stock = initialStock,
                Price = 10.50m,
                BrandId = 1,
                CategoryId = 1
            };

            _mockRepository.Setup(r => r.GetById(productId))
                          .Returns(product);

            // Act
            _productService.UpdateStock(productId, amountToAdd);

            // Assert
            Assert.Equal(expectedFinalStock, product.Stock);
            _mockRepository.Verify(r => r.GetById(productId), Times.Once);
            _mockRepository.Verify(r => r.Update(product), Times.Once);
        }

        [Fact]
        public void UpdateStock_WithNegativeAmountCausingNegativeStock_ShouldThrowValidationException()
        {
            // Arrange
            int productId = 1;
            int initialStock = 10;
            int amountToRemove = -15; // Tentativa de remover mais do que existe

            var product = new Product
            {
                Id = productId,
                Name = "Produto Teste",
                Stock = initialStock,
                Price = 10.50m,
                BrandId = 1,
                CategoryId = 1
            };

            _mockRepository.Setup(r => r.GetById(productId))
                          .Returns(product);

            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() =>
                _productService.UpdateStock(productId, amountToRemove));

            Assert.Equal("O stock não pode ficar negativo.", exception.Message);
            Assert.Equal(initialStock, product.Stock); // Stock não deve ter mudado
            _mockRepository.Verify(r => r.GetById(productId), Times.Once);
            _mockRepository.Verify(r => r.Update(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public void UpdateStock_WithNegativeAmountButValidResult_ShouldUpdateStock()
        {
            // Arrange
            int productId = 1;
            int initialStock = 50;
            int amountToRemove = -20; // Remover 20 unidades
            int expectedFinalStock = 30;

            var product = new Product
            {
                Id = productId,
                Name = "Produto Teste",
                Stock = initialStock,
                Price = 10.50m,
                BrandId = 1,
                CategoryId = 1
            };

            _mockRepository.Setup(r => r.GetById(productId))
                          .Returns(product);

            // Act
            _productService.UpdateStock(productId, amountToRemove);

            // Assert
            Assert.Equal(expectedFinalStock, product.Stock);
            _mockRepository.Verify(r => r.GetById(productId), Times.Once);
            _mockRepository.Verify(r => r.Update(product), Times.Once);
        }

        [Fact]
        public void GetById_WhenProductNotFound_ShouldThrowNotFoundException()
        {
            // Arrange
            int productId = 999;
            _mockRepository.Setup(r => r.GetById(productId))
                          .Returns((Product?)null);

            // Act & Assert
            var exception = Assert.Throws<NotFoundException>(() =>
                _productService.GetById(productId));

            Assert.Equal($"Produto com o ID {productId} não encontrado.", exception.Message);
            _mockRepository.Verify(r => r.GetById(productId), Times.Once);
        }
    }
}