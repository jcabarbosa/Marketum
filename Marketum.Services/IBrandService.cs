using System.Collections.Generic;
using Marketum.Domain;

namespace Marketum.Services
{
    public interface IBrandService
    {
        Brand AddBrand(string name);
        void UpdateBrand(Brand brand);
        void RemoveBrand(int id);
        List<Brand> GetAllBrands();
        Brand? GetBrandById(int id);
    }
}
