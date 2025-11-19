using Marketum.Domain;
using Marketum.Domain.Exceptions;
using System.Collections.Generic;

namespace Marketum.Services
{
    public interface IProductService
    {
        Product AddProduct(string name, string brand, decimal price, int stock, int categoryId);
        List<Product> GetAllProducts();
        Product GetById(int id);
        void UpdateStock(int productId, int amount);
        void RemoveProduct(int id);
    }
}