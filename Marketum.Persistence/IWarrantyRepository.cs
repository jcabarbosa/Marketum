using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface IWarrantyRepository
    {
        Warranty Add(Warranty warranty);
        List<Warranty> GetAll();
        List<Warranty> GetActive();
        Warranty? GetById(int id);
        void Update(Warranty warranty);
        void Delete(int id);
    }
}