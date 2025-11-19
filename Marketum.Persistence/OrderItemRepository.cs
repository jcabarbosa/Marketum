using Marketum.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Marketum.Persistence
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly string _filePath = "order_items.txt";

        public void AddItems(int orderId, List<OrderItem> items)
        {
            var lines = items.Select(i =>
                $"{orderId};{i.ProductId};{i.ProductName};{i.Price.ToString(System.Globalization.CultureInfo.InvariantCulture)};{i.Quantity}");

            File.AppendAllLines(_filePath, lines);
        }

        public List<OrderItem> GetItemsByOrderId(int orderId)
        {
            if (!File.Exists(_filePath))
                return new List<OrderItem>();

            return File.ReadAllLines(_filePath)
                       .Select(line => line.Split(';'))
                       .Where(p => int.Parse(p[0]) == orderId)
                       .Select(p => new OrderItem
                       {
                           ProductId = int.Parse(p[1]),
                           ProductName = p[2],
                           Price = decimal.Parse(p[3], System.Globalization.CultureInfo.InvariantCulture),
                           Quantity = int.Parse(p[4])
                       })
                       .ToList();
        }
    }
}
