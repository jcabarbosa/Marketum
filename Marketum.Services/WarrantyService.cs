using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;

namespace Marketum.Services
{
    public class WarrantyService : IWarrantyService
    {
        private readonly IWarrantyRepository _warrantyRepo;

        public WarrantyService(IWarrantyRepository warrantyRepo)
        {
            _warrantyRepo = warrantyRepo;
        }

        public Warranty CreateWarranty(string name, int durationMonths, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Nome da garantia é obrigatório.");

            if (durationMonths <= 0)
                throw new ValidationException("Duração da garantia deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ValidationException("Descrição da garantia é obrigatória.");

            var warranty = new Warranty
            {
                Name = name,
                DurationMonths = durationMonths,
                Description = description,
                IsActive = true
            };

            return _warrantyRepo.Add(warranty);
        }

        public List<Warranty> GetAllWarranties()
        {
            return _warrantyRepo.GetAll();
        }

        public List<Warranty> GetActiveWarranties()
        {
            return _warrantyRepo.GetActive();
        }

        public Warranty? GetById(int id)
        {
            return _warrantyRepo.GetById(id);
        }

        public void UpdateWarranty(Warranty warranty)
        {
            if (string.IsNullOrWhiteSpace(warranty.Name))
                throw new ValidationException("Nome da garantia é obrigatório.");

            if (warranty.DurationMonths <= 0)
                throw new ValidationException("Duração da garantia deve ser maior que zero.");

            _warrantyRepo.Update(warranty);
        }

        public void RemoveWarranty(int warrantyId)
        {
            var warranty = _warrantyRepo.GetById(warrantyId);
            if (warranty == null)
                throw new NotFoundException("Garantia não encontrada.");

            _warrantyRepo.Delete(warrantyId);
        }

        public void DeactivateWarranty(int warrantyId)
        {
            var warranty = _warrantyRepo.GetById(warrantyId);
            if (warranty == null)
                throw new NotFoundException("Garantia não encontrada.");

            warranty.IsActive = false;
            _warrantyRepo.Update(warranty);
        }
    }
}