using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITypeRepository
    {
        Task<ProductType> GetTypeByIdAsync(int id);
        Task<IReadOnlyList<ProductType>> GetTypesAsync();
        Task<ProductType> AddTypesAsync(ProductType typeToAdd);
    }
}