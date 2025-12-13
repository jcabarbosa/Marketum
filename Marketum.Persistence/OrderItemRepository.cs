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
                       .Where(p => p.Length >= 5 && int.TryParse(p[0], out int oid) && oid == orderId)
                       .Select(p => new OrderItem
                       {
                           OrderId = int.TryParse(p[0], out int oid) ? oid : 0,
                           ProductId = int.TryParse(p[1], out int pid) ? pid : 0,
                           ProductName = p[2],
                           Price = decimal.TryParse(p[3], System.Globalization.CultureInfo.InvariantCulture, out decimal price) ? price : 0,
                           Quantity = int.TryParse(p[4], out int qty) ? qty : 0
                       })
                       .ToList();
        }

        public List<OrderItem> GetAllItems()
        {
            if (!File.Exists(_filePath))
                return new List<OrderItem>();

            return File.ReadAllLines(_filePath)
                       .Select(line => line.Split(';'))
                       .Where(p => p.Length >= 5)
                       .Select(p => new OrderItem
                       {
                           OrderId = int.TryParse(p[0], out int oid) ? oid : 0,
                           ProductId = int.TryParse(p[1], out int pid) ? pid : 0,
                           ProductName = p[2],
                           Price = decimal.TryParse(p[3], System.Globalization.CultureInfo.InvariantCulture, out decimal price) ? price : 0,
                           Quantity = int.TryParse(p[4], out int qty) ? qty : 0
                       })
                       .ToList();
        }
    }
}
