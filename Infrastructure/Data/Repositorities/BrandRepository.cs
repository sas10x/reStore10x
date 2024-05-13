using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Infrastructure.Data
{
    public class BrandsRepository : IBrandRepository
    {
        private readonly StoreContext _context;
        public BrandsRepository(StoreContext context) 
        {
            _context = context;
        }
        
        public async Task<ProductBrand> GetBrandByIdAsync(int id)
        {
            return await _context.ProductBrands.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<ProductBrand> AddBrandAsync(ProductBrand brandToAdd)
        {
            _context.ProductBrands.Add(brandToAdd);
            await _context.SaveChangesAsync();
            return brandToAdd;
        }
    }
}