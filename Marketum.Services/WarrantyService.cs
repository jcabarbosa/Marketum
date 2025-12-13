using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;

namespace Marketum.Services
{
    public class WarrantyService : IWarrantyService
    {
        private readonly IWarrantyRepository _warrantyRepo;
        private readonly IProductRepository _productRepo;

        public WarrantyService(IWarrantyRepository warrantyRepo, IProductRepository productRepo)
        {
            _warrantyRepo = warrantyRepo;
            _productRepo = productRepo;
        }

        public Warranty CreateWarranty(int productId, int durationMonths, string description)
        {
            var product = _productRepo.GetById(productId);
            if (product == null)
                throw new NotFoundException("Produto não encontrado.");

            if (durationMonths <= 0)
                throw new ValidationException("Duração da garantia deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ValidationException("Descrição da garantia é obrigatória.");

            var warranty = new Warranty
            {
                ProductId = productId,
                DurationMonths = durationMonths,
                Description = description
            };

            return _warrantyRepo.Add(warranty);
        }

        public void AssociateWarrantyToProduct(int warrantyId, int productId)
        {
            var warranty = _warrantyRepo.GetById(warrantyId);
            if (warranty == null)
                throw new NotFoundException("Garantia não encontrada.");

            var product = _productRepo.GetById(productId);
            if (product == null)
                throw new NotFoundException("Produto não encontrado.");

            product.WarrantyId = warrantyId;
            _productRepo.Update(product);
        }

        public Warranty? GetWarrantyByProductId(int productId)
        {
            return _warrantyRepo.GetByProductId(productId);
        }

        public List<Warranty> GetAllWarranties()
        {
            return _warrantyRepo.GetAll();
        }

        public void RemoveWarranty(int warrantyId)
        {
            var warranty = _warrantyRepo.GetById(warrantyId);
            if (warranty == null)
                throw new NotFoundException("Garantia não encontrada.");

            _warrantyRepo.Delete(warrantyId);
        }
    }
}