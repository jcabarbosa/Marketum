using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface IWarrantyRepository
    {
        Warranty Add(Warranty warranty);
        List<Warranty> GetAll();
        Warranty? GetById(int id);
        Warranty? GetByProductId(int productId);
        void Update(Warranty warranty);
        void Delete(int id);
    }
}