using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketum.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderItemRepository _orderItemRepo;
        private readonly IProductRepository _productRepo;
        private readonly IClientRepository _clientRepo;
        private readonly ICampaignService _campaignService;

        public OrderService(
            IOrderRepository orderRepo,
            IOrderItemRepository orderItemRepo,
            IProductRepository productRepo,
            IClientRepository clientRepo,
            ICampaignService campaignService)
        {
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
            _productRepo = productRepo;
            _clientRepo = clientRepo;
            _campaignService = campaignService;
        }

        public Order CreateOrder(
            int clientId,
            int employeeId,
            UserRole employeeRole,
            PaymentMethod paymentMethod,
            List<(int productId, int quantity)> items)
        {
            if (paymentMethod == PaymentMethod.Cash && employeeRole != UserRole.Admin)
                throw new ValidationException("Apenas administradores podem usar 'Cash'.");

            var client = _clientRepo.GetById(clientId);
            if (client == null)
                throw new NotFoundException("Cliente não encontrado.");

            if (items == null || items.Count == 0)
                throw new ValidationException("A encomenda deve conter produtos.");

            var orderItems = new List<OrderItem>();
            var products = new List<Product>();

            foreach (var (productId, qty) in items)
            {
                if (qty <= 0)
                    throw new ValidationException("Quantidade inválida.");

                var product = _productRepo.GetById(productId);
                if (product == null)
                    throw new NotFoundException($"Produto {productId} não encontrado.");

                if (product.Stock < qty)
                    throw new ValidationException($"Stock insuficiente para '{product.Name}'.");

                products.Add(product);

                orderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = qty
                });
            }

            Campaign? campaign = null;

            var categories = products.Select(p => p.CategoryId).Distinct().ToList();

            if (categories.Count == 1)
            {
                campaign = _campaignService.GetActiveCampaignForCategory(categories[0])
                           ?? _campaignService.GetActiveGlobalCampaign();
            }
            else
            {
                campaign = _campaignService.GetActiveGlobalCampaign();
            }

            var order = new Order
            {
                CustomerId = clientId,
                EmployeeId = employeeId,
                OrderDate = DateTime.Now,
                PaymentMethod = paymentMethod,
                Items = orderItems,
                CampaignId = campaign?.Id,
                Campaign = campaign,
                Status = OrderStatus.Created
            };

            order = _orderRepo.Add(order);

            _orderItemRepo.AddItems(order.Id, orderItems);

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                var qty = items[i].quantity;

                product.Stock -= qty;
                if (product.Stock < 0) product.Stock = 0;

                _productRepo.Update(product);
            }

            return order;
        }

        public List<Order> GetAllOrders()
        {
            var orders = _orderRepo.GetAll();

            foreach (var order in orders)
            {
                order.Items = _orderItemRepo.GetItemsByOrderId(order.Id);

                if (order.CampaignId.HasValue)
                {
                    try
                    {
                        var campaigns = _campaignService.GetAllCampaigns();
                        order.Campaign = campaigns
                            .FirstOrDefault(c => c.Id == order.CampaignId.Value);
                    }
                    catch
                    {
                        order.Campaign = null;
                    }
                }
            }

            return orders;
        }

        public void ConfirmOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order.Status != OrderStatus.Created)
                throw new ValidationException("Apenas encomendas criadas podem ser confirmadas.");
            
            order.Status = OrderStatus.Processing;
            _orderRepo.Update(order);
        }

        public void CancelOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order.Status == OrderStatus.Shipped || order.Status == OrderStatus.Completed)
                throw new ValidationException("Não é possível cancelar encomendas enviadas ou concluídas.");
            
            order.Status = OrderStatus.Cancelled;
            _orderRepo.Update(order);
        }

        public void MarkAsPaid(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order.Status != OrderStatus.Created)
                throw new ValidationException("Apenas encomendas criadas podem ser marcadas como pagas.");
            
            order.Status = OrderStatus.Paid;
            _orderRepo.Update(order);
        }

        private Order GetOrderById(int orderId)
        {
            var order = _orderRepo.GetById(orderId);
            if (order == null)
                throw new NotFoundException("Encomenda não encontrada.");
            return order;
        }
    }
}
