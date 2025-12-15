using System.Collections.Generic;
using Marketum.Domain;
using Marketum.Persistence;

namespace Marketum.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Category AddCategory(string name)
        {
            var category = new Category
            {
                Name = name
            };

            return _repository.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _repository.Update(category);
        }

        public void RemoveCategory(int id)
        {
            _repository.Delete(id);
        }

        public List<Category> GetAllCategories()
        {
            return _repository.GetAll();
        }

        public Category? GetCategoryById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
