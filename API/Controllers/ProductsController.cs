using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
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

        private readonly IProductRepository _repo;

        public ProductsController( IProductRepository repo  , ILogger<ProductsController> logger)
        {
            _repo = repo;

            _logger = logger;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Product>>> GteProducts()
        {
            var products = await _repo.GteProductsAsync();
            return Ok (products);
            // return "this will be a list of products";
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GteProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
            
        }


    
    }
}