using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly StoreContext _context;

        public ProductsController( StoreContext context  , ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Product>>> GteProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok (products);
            // return "this will be a list of products";
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GteProduct(int id)
        {
            return await _context.Products.FindAsync(id);
            
        }


    
    }
}