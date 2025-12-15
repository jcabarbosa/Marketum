using Marketum.Domain;

namespace Marketum.Persistence
{
    public class BrandRepository : IBrandRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "brands.txt");
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
                    foreach (var line in File.ReadAllLines(_filePath))
                    {
                        var parts = line.Split(';');
                        if (parts.Length >= 2)
                        {
                            _brands.Add(new Brand
                            {
                                Id = int.Parse(parts[0]),
                                Name = parts[1]
                            });
                        }
                    }
                    _nextId = _brands.Any() ? _brands.Max(b => b.Id) + 1 : 1;
                }
                catch { }
            }
        }

        private void SaveToFile()
        {
            try
            {
                var lines = _brands.Select(b => $"{b.Id};{b.Name}");
                File.WriteAllLines(_filePath, lines);
            }
            catch { }
        }
    }
}