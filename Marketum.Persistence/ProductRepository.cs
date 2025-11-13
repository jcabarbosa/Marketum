using Marketum.Domain;

namespace Marketum.Persistence
{
    /// <summary>
    /// Repositório para gestão de produtos com persistência em ficheiro.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly string _filePath = "products.txt";
        private List<Product> _products;

        public ProductRepository()
        {
            _products = LoadFromFile();
        }

        public Product Add(Product product)
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
            SaveToFile();
            return product;
        }

        public List<Product> GetAll()
        {
            return new List<Product>(_products);
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Carrega os produtos do ficheiro de texto.
        /// </summary>
        private List<Product> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Product>();

            var products = new List<Product>();
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split(';');
                if (parts.Length == 7)
                {
                    products.Add(new Product
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Description = parts[2],
                        Price = decimal.Parse(parts[3]),
                        Stock = int.Parse(parts[4]),
                        CategoryId = int.Parse(parts[5]),
                        BrandId = int.Parse(parts[6])
                    });
                }
            }
            return products;
        }

        /// <summary>
        /// Guarda os produtos no ficheiro de texto.
        /// </summary>
        private void SaveToFile()
        {
            var lines = _products.Select(p => $"{p.Id};{p.Name};{p.Description};{p.Price};{p.Stock};{p.CategoryId};{p.BrandId}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}
