using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context) 
        {
            _context = context;
        }
        
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> AddProductsAsync(Product productToAdd)
        {
            _context.Products.Add(productToAdd);
            await _context.SaveChangesAsync();
            return productToAdd;
        }
        
       public async Task<PagedList<ProductReturnDto>> GetAllProductsAsync(ProductParams productParams)
        {
            var query = _context.Products
                .Sort(productParams.OrderBy)
                .Search(productParams.SearchTerm)
                .Filter(productParams.Brands, productParams.Types)
                .Select(p => new ProductReturnDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    PictureUrl = p.PictureUrl,
                    ProductType = p.ProductType.Name,
                    ProductBrand = p.ProductBrand.Name,
                })
                .AsQueryable();

            return await PagedList<ProductReturnDto>.ToPagedList(query, productParams.PageNumber, productParams.PageSize);
        }
    }
}