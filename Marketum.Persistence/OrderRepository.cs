using Marketum.Domain;

namespace Marketum.Persistence
{
    /// <summary>
    /// Repositório para gestão de encomendas com persistência em ficheiro.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly string _filePath = "orders.txt";
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
                if (parts.Length == 4)
                {
                    orders.Add(new Order
                    {
                        Id = int.Parse(parts[0]),
                        CustomerId = int.Parse(parts[1]),
                        OrderDate = DateTime.Parse(parts[2])
                        // TotalAmount é calculado automaticamente pela propriedade
                    });
                }
            }
            return orders;
        }

        /// <summary>
        /// Guarda as encomendas no ficheiro de texto (apenas campos principais).
        /// </summary>
        private void SaveToFile()
        {
            // Adicionado o CultureInfo.InvariantCulture no TotalAmount para garantir que usa ponto e não vírgula
            var lines = _orders.Select(o => $"{o.Id};{o.CustomerId};{o.OrderDate:yyyy-MM-dd HH:mm:ss};{o.TotalAmount.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}
