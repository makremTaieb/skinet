using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context )
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GteProductBrandsAsync()
        {
            return await  _context.ProductBrand.ToArrayAsync();
            
        }

        public async Task<IReadOnlyList<ProductType>> GteProductTypesAsync()
        {
            return await _context.ProductType.ToListAsync();     
        }

        async Task<Product>  IProductRepository.GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        async Task<IReadOnlyList<Product>> IProductRepository.GteProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .ToListAsync();
        }
    }
}