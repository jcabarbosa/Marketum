using Marketum.Domain;
using System.Text.Json;

namespace Marketum.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _filePath = "categories.txt";
        private List<Category> _categories;
        private int _nextId;

        public CategoryRepository()
        {
            LoadFromFile();
        }

        public Category Add(Category category)
        {
            category.Id = _nextId++;
            _categories.Add(category);
            SaveToFile();
            return category;
        }

        public List<Category> GetAll()
        {
            return new List<Category>(_categories);
        }

        public Category? GetById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category category)
        {
            var existing = GetById(category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
                SaveToFile();
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _categories.Remove(category);
                SaveToFile();
            }
        }

        private void LoadFromFile()
        {
            _categories = new List<Category>();
            _nextId = 1;

            if (File.Exists(_filePath))
            {
                try
                {
                    var json = File.ReadAllText(_filePath);
                    var data = JsonSerializer.Deserialize<List<Category>>(json);
                    if (data != null)
                    {
                        _categories = data;
                        _nextId = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;
                    }
                }
                catch { }
            }
        }

        private void SaveToFile()
        {
            try
            {
                var json = JsonSerializer.Serialize(_categories, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch { }
        }
    }
}