using Marketum.Domain;
using System.Collections.Generic;

namespace Marketum.Services
{
    public interface IOrderService
    {
        Order CreateOrder(
            int clientId,
            UserRole employeeRole,
            PaymentMethod paymentMethod,
            List<(int productId, int quantity)> items);

        List<Order> GetAllOrders();
    }
}
