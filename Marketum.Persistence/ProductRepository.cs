using Marketum.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existing == null) return;

            existing.Name = product.Name;
            existing.Brand = product.Brand;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
            existing.CategoryId = product.CategoryId;

            SaveToFile();
        }

        public void Delete(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p == null) return;

            _products.Remove(p);
            SaveToFile();
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
                if (parts.Length == 6)
                {
                    products.Add(new Product
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Brand = parts[2],
                        Price = decimal.Parse(parts[3]),
                        Stock = int.Parse(parts[4]),
                        CategoryId = int.Parse(parts[5])
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
            var lines = _products.Select(p => $"{p.Id};{p.Name};{p.Brand};{p.Price};{p.Stock};{p.CategoryId}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}
