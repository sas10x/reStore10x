using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Helpers;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<Product> AddProductsAsync(Product productToAdd);
        Task<PagedList<ProductReturnDto>> GetAllProductsAsync(ProductParams productParams);
    }
}