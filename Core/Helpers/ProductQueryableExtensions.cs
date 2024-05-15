using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Helpers
{
    public static class ProductQueryableExtensions
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query, string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy)) return query.OrderBy(p => p.Name);

            query = orderBy switch
            {
                "price" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name)
            };

            return query;
        }

        public static IQueryable<Product> Search(this IQueryable<Product> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<Product> Filter(this IQueryable<Product> query, string brands, string types)
        {
            var brandList = string.IsNullOrEmpty(brands) ? new List<string>() : brands.ToLower().Split(",").ToList();
            var typeList = string.IsNullOrEmpty(types) ? new List<string>() : types.ToLower().Split(",").ToList();

            if (brandList.Any())
            {
                query = query.Where(p => brandList.Contains(p.ProductBrand.Name.ToLower()));
            }

            if (typeList.Any())
            {
                query = query.Where(p => typeList.Contains(p.ProductType.Name.ToLower()));
            }

            return query;
        }
    }
}