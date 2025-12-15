using Marketum.Domain;

namespace Marketum.Persistence
{
    /// <summary>
    /// Repositório para gestão de garantias com persistência em ficheiro
    /// </summary>
    public class WarrantyRepository : IWarrantyRepository
    {
        private readonly string _filePath = "warranties.txt";
        private List<Warranty> _warranties;

        public WarrantyRepository()
        {
            _warranties = LoadFromFile();
        }

        public Warranty Add(Warranty warranty)
        {
            warranty.Id = _warranties.Count > 0 ? _warranties.Max(w => w.Id) + 1 : 1;
            _warranties.Add(warranty);
            SaveToFile();
            return warranty;
        }

        public List<Warranty> GetAll()
        {
            return new List<Warranty>(_warranties);
        }

        public Warranty? GetById(int id)
        {
            return _warranties.FirstOrDefault(w => w.Id == id);
        }

        public List<Warranty> GetActive()
        {
            return _warranties.Where(w => w.IsActive).ToList();
        }

        public void Update(Warranty warranty)
        {
            var existing = _warranties.FirstOrDefault(w => w.Id == warranty.Id);
            if (existing == null) return;

            existing.Name = warranty.Name;
            existing.DurationMonths = warranty.DurationMonths;
            existing.Description = warranty.Description;
            existing.IsActive = warranty.IsActive;

            SaveToFile();
        }

        public void Delete(int id)
        {
            var warranty = _warranties.FirstOrDefault(w => w.Id == id);
            if (warranty == null) return;

            _warranties.Remove(warranty);
            SaveToFile();
        }

        private List<Warranty> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Warranty>();

            var warranties = new List<Warranty>();
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split(';');
                if (parts.Length >= 5)
                {
                    warranties.Add(new Warranty
                    {
                        Id = int.TryParse(parts[0], out int id) ? id : 0,
                        Name = parts[1],
                        DurationMonths = int.TryParse(parts[2], out int duration) ? duration : 0,
                        Description = parts[3],
                        IsActive = bool.TryParse(parts[4], out bool isActive) ? isActive : true
                    });
                }
            }
            return warranties;
        }

        private void SaveToFile()
        {
            var lines = _warranties.Select(w => $"{w.Id};{w.Name};{w.DurationMonths};{w.Description};{w.IsActive}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}