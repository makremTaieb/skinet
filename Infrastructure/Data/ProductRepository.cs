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

        async Task<Product>  IProductRepository.GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        async Task<IReadOnlyList<Product>> IProductRepository.GteProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}