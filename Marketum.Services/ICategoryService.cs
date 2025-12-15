using System.Collections.Generic;
using Marketum.Domain;

namespace Marketum.Services
{
    public interface ICategoryService
    {
        Category AddCategory(string name);
        void UpdateCategory(Category category);
        void RemoveCategory(int id);
        List<Category> GetAllCategories();
        Category? GetCategoryById(int id);
    }
}
