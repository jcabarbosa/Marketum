using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface IBrandRepository
    {
        Brand Add(Brand brand);
        List<Brand> GetAll();
        Brand? GetById(int id);
        void Update(Brand brand);
        void Delete(int id);
    }
}