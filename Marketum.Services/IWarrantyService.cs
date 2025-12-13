using Marketum.Domain;

namespace Marketum.Services
{
    public interface IWarrantyService
    {
        Warranty CreateWarranty(int productId, int durationMonths, string description);
        void AssociateWarrantyToProduct(int warrantyId, int productId);
        Warranty? GetWarrantyByProductId(int productId);
        List<Warranty> GetAllWarranties();
        void RemoveWarranty(int warrantyId);
    }
}