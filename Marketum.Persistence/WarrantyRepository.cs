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

        public Warranty? GetByProductId(int productId)
        {
            return _warranties.FirstOrDefault(w => w.ProductId == productId);
        }

        public void Update(Warranty warranty)
        {
            var existing = _warranties.FirstOrDefault(w => w.Id == warranty.Id);
            if (existing == null) return;

            existing.ProductId = warranty.ProductId;
            existing.DurationMonths = warranty.DurationMonths;
            existing.Description = warranty.Description;

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
                if (parts.Length >= 4)
                {
                    warranties.Add(new Warranty
                    {
                        Id = int.TryParse(parts[0], out int id) ? id : 0,
                        ProductId = int.TryParse(parts[1], out int productId) ? productId : 0,
                        DurationMonths = int.TryParse(parts[2], out int duration) ? duration : 0,
                        Description = parts[3]
                    });
                }
            }
            return warranties;
        }

        private void SaveToFile()
        {
            var lines = _warranties.Select(w => $"{w.Id};{w.ProductId};{w.DurationMonths};{w.Description}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}