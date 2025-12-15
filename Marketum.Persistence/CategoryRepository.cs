using Marketum.Domain;

namespace Marketum.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "categories.txt");
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
                    foreach (var line in File.ReadAllLines(_filePath))
                    {
                        var parts = line.Split(';');
                        if (parts.Length >= 2)
                        {
                            _categories.Add(new Category
                            {
                                Id = int.Parse(parts[0]),
                                Name = parts[1]
                            });
                        }
                    }
                    _nextId = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;
                }
                catch { }
            }
        }

        private void SaveToFile()
        {
            try
            {
                var lines = _categories.Select(c => $"{c.Id};{c.Name}");
                File.WriteAllLines(_filePath, lines);
            }
            catch { }
        }
    }
}