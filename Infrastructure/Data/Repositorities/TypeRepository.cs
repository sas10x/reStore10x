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
    public class TypeRepository : ITypeRepository
    {
        private readonly StoreContext _context;
        public TypeRepository(StoreContext context) 
        {
            _context = context;
        }
        
        public async Task<ProductType> GetTypeByIdAsync(int id)
        {
            return await _context.ProductTypes.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductType>> GetTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> AddTypesAsync(ProductType typeToAdd)
        {
            _context.ProductTypes.Add(typeToAdd);
            await _context.SaveChangesAsync();
            return typeToAdd;
        }
    }
}