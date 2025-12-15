using System.Collections.Generic;
using Marketum.Domain;
using Marketum.Persistence;

namespace Marketum.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository)
        {
            _repository = repository;
        }

        public Brand AddBrand(string name)
        {
            var brand = new Brand
            {
                Name = name
            };

            return _repository.Add(brand);
        }

        public void UpdateBrand(Brand brand)
        {
            _repository.Update(brand);
        }

        public void RemoveBrand(int id)
        {
            _repository.Delete(id);
        }

        public List<Brand> GetAllBrands()
        {
            return _repository.GetAll();
        }

        public Brand? GetBrandById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
