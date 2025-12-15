using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        List<Category> GetAll();
        Category? GetById(int id);
        void Update(Category category);
        void Delete(int id);
    }
}