using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface IProductRepository
    {
        Product Add(Product product);
        List<Product> GetAll();
        Product? GetById(int id);
    }
}
