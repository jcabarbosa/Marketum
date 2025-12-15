using Marketum.Domain;
using System.Text.Json;

namespace Marketum.Persistence
{
    public class BrandRepository : IBrandRepository
    {
        private readonly string _filePath = "brands.txt";
        private List<Brand> _brands;
        private int _nextId;

        public BrandRepository()
        {
            LoadFromFile();
        }

        public Brand Add(Brand brand)
        {
            brand.Id = _nextId++;
            _brands.Add(brand);
            SaveToFile();
            return brand;
        }

        public List<Brand> GetAll()
        {
            return new List<Brand>(_brands);
        }

        public Brand? GetById(int id)
        {
            return _brands.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Brand brand)
        {
            var existing = GetById(brand.Id);
            if (existing != null)
            {
                existing.Name = brand.Name;
                SaveToFile();
            }
        }

        public void Delete(int id)
        {
            var brand = GetById(id);
            if (brand != null)
            {
                _brands.Remove(brand);
                SaveToFile();
            }
        }

        private void LoadFromFile()
        {
            _brands = new List<Brand>();
            _nextId = 1;

            if (File.Exists(_filePath))
            {
                try
                {
                    var json = File.ReadAllText(_filePath);
                    var data = JsonSerializer.Deserialize<List<Brand>>(json);
                    if (data != null)
                    {
                        _brands = data;
                        _nextId = _brands.Any() ? _brands.Max(b => b.Id) + 1 : 1;
                    }
                }
                catch { }
            }
        }

        private void SaveToFile()
        {
            try
            {
                var json = JsonSerializer.Serialize(_brands, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch { }
        }
    }
}