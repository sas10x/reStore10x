using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBrandRepository
    {
        Task<ProductBrand> GetBrandByIdAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetBrandsAsync();
        Task<ProductBrand> AddBrandAsync(ProductBrand brandToAdd);
    }
}