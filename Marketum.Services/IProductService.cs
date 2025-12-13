using Marketum.Domain;
using Marketum.Domain.Exceptions;
using System.Collections.Generic;

namespace Marketum.Services
{
    public interface IProductService
    {
        Product AddProduct(string name, int brandId, decimal price, int stock, int categoryId, int? warrantyId = null);
        List<Product> GetAllProducts();
        Product GetById(int id);
        void UpdateStock(int productId, int amount);
        void RemoveProduct(int id);
    }
}