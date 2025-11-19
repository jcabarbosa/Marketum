using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;
using System.Collections.Generic;

namespace Marketum.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product AddProduct(string name, string brand, decimal price, int stock, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Introduza um nome válido.");

            if (string.IsNullOrWhiteSpace(brand))
                throw new ValidationException("Intoduza uma marca válida.");

            if (price <= 0)
                throw new ValidationException("O preço tem de ser maior que zero.");

            if (stock < 0)
                throw new ValidationException("O stock não pode ser negativo.");

            if (categoryId <= 0)
                throw new ValidationException("CategoryId inválido.");

            var product = new Product
            {
                Name = name,
                Brand = brand,
                Price = price,
                Stock = stock,
                CategoryId = categoryId
            };

            return _repository.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public Product GetById(int id)
        {
            var product = _repository.GetById(id);

            if (product == null)
                throw new NotFoundException($"Produto com o ID {id} não encontrado.");

            return product;
        }

        public void UpdateStock(int productId, int amount)
        {
            var product = GetById(productId);

            var newStock = product.Stock + amount;

            if (newStock < 0)
                throw new ValidationException("O stock não pode ficar negativo.");

            product.Stock = newStock;
            _repository.Update(product);
        }

        public void RemoveProduct(int id)
        {
            var product = _repository.GetById(id);

            if (product == null)
                throw new NotFoundException($"Produto com o ID {id} não existe.");

            _repository.Delete(id);
        }
    }
}
