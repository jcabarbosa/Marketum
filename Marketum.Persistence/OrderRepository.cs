using Marketum.Domain;

namespace Marketum.Persistence
{
    /// <summary>
    /// Repositório para gestão de encomendas com persistência em ficheiro.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "orders.txt");
        private List<Order> _orders;

        public OrderRepository()
        {
            _orders = LoadFromFile();
        }

        public Order Add(Order order)
        {
            order.Id = _orders.Count > 0 ? _orders.Max(o => o.Id) + 1 : 1;
            _orders.Add(order);
            SaveToFile();
            return order;
        }

        public List<Order> GetAll()
        {
            return new List<Order>(_orders);
        }

        public Order? GetById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void Update(Order order)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.Status = order.Status;
                SaveToFile();
            }
        }

        public void Remove(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _orders.Remove(order);
                SaveToFile();
            }
        }

        /// <summary>
        /// Carrega as encomendas do ficheiro de texto.
        /// </summary>
        private List<Order> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Order>();

            var orders = new List<Order>();
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split(';');
                if (parts.Length >= 4)
                {
                    var order = new Order
                    {
                        Id = int.Parse(parts[0]),
                        CustomerId = int.Parse(parts[1]),
                        OrderDate = DateTime.Parse(parts[2])
                    };
                    
                    if (parts.Length >= 5 && int.TryParse(parts[4], out int employeeId))
                        order.EmployeeId = employeeId;
                    
                    if (parts.Length >= 6 && Enum.TryParse<OrderStatus>(parts[5], out OrderStatus status))
                        order.Status = status;
                        
                    if (parts.Length >= 7 && Enum.TryParse<PaymentMethod>(parts[6], out PaymentMethod paymentMethod))
                        order.PaymentMethod = paymentMethod;
                    
                    orders.Add(order);
                }
            }
            return orders;
        }

        /// <summary>
        /// Guarda as encomendas no ficheiro de texto (apenas campos principais).
        /// </summary>
        private void SaveToFile()
        {
            var lines = _orders.Select(o => $"{o.Id};{o.CustomerId};{o.OrderDate:yyyy-MM-dd HH:mm:ss};{o.TotalAmount.ToString(System.Globalization.CultureInfo.InvariantCulture)};{o.EmployeeId};{o.Status};{o.PaymentMethod}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}
