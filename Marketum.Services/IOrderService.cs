using Marketum.Domain;
using System.Collections.Generic;

namespace Marketum.Services
{
    public interface IOrderService
    {
        Order CreateOrder(
            int clientId,
            int employeeId,
            UserRole employeeRole,
            PaymentMethod paymentMethod,
            List<(int productId, int quantity)> items);

        List<Order> GetAllOrders();
        void ConfirmOrder(int orderId);
        void CancelOrder(int orderId);
        void MarkAsPaid(int orderId);
        void ShipOrder(int orderId);
        void CompleteOrder(int orderId);
    }
}
