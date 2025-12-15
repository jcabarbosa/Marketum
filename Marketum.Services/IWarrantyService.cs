using Marketum.Domain;

namespace Marketum.Services
{
    public interface IWarrantyService
    {
        Warranty CreateWarranty(string name, int durationMonths, string description);
        List<Warranty> GetAllWarranties();
        List<Warranty> GetActiveWarranties();
        Warranty? GetById(int id);
        void UpdateWarranty(Warranty warranty);
        void RemoveWarranty(int warrantyId);
        void DeactivateWarranty(int warrantyId);
    }
}