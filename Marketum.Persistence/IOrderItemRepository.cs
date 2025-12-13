using Marketum.Domain;
using System.Collections.Generic;

namespace Marketum.Persistence
{
    public interface IOrderItemRepository
    {
        void AddItems(int orderId, List<OrderItem> items);
        List<OrderItem> GetItemsByOrderId(int orderId);
        List<OrderItem> GetAllItems();
    }
}
