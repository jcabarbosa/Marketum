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
            existing.BrandId = product.BrandId;
            existing.WarrantyId = product.WarrantyId;
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
                if (parts.Length >= 6)
                {
                    var product = new Product
                    {
                        Id = int.TryParse(parts[0], out int id) ? id : 0,
                        Name = parts[1],
                        BrandId = int.TryParse(parts[2], out int brandId) ? brandId : 0,
                        Price = decimal.TryParse(parts[3], out decimal price) ? price : 0,
                        Stock = int.TryParse(parts[4], out int stock) ? stock : 0,
                        CategoryId = int.TryParse(parts[5], out int categoryId) ? categoryId : 0
                    };
                    
                    if (parts.Length >= 7 && int.TryParse(parts[6], out int warrantyId) && warrantyId > 0)
                        product.WarrantyId = warrantyId;
                    
                    products.Add(product);
                }
            }
            return products;
        }

        /// <summary>
        /// Guarda os produtos no ficheiro de texto.
        /// </summary>
        private void SaveToFile()
        {
            var lines = _products.Select(p => $"{p.Id};{p.Name};{p.BrandId};{p.Price};{p.Stock};{p.CategoryId};{p.WarrantyId?.ToString() ?? ""}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}
