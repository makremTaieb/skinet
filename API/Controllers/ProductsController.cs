using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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
        // private readonly IProductRepository _repo;
        // public ProductsController( IProductRepository repo  , ILogger<ProductsController> logger)
        // {
        //     _repo = repo;
        //     _logger = logger;
        // }
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        
        public ProductsController(IGenericRepository<Product> productRepo ,IGenericRepository<ProductBrand> productBrandRepo , IGenericRepository<ProductType> productTypeRepo , IMapper mapper )
        {
            _mapper = mapper;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productRepo = productRepo;
            
        }

        [HttpGet]
        public async  Task<ActionResult<IReadOnlyList<ProductToRetuenDto>>> GteProducts()
        {
            // var products = await _repo.GteProductsAsync();
            // var products = await _productRepo.ListAllAsync(); // Generic
            // var products = await _productRepo.ListAsync(spec); // Generic with specification 
            // return products.Select(product => new ProductToRetuenDto {
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     PictureUrl = product.PictureUrl,
            //     Price = product.Price,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name
            // }).ToList();
            var spec = new ProductWithTypesAndBrctorandsSpecification();
            var products = await _productRepo.ListAsync(spec); // Generic with specification 
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToRetuenDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToRetuenDto>> GteProduct(int id)
        {
            // return await _repo.GetProductByIdAsync(id);
            // return await _productRepo.GetByIdAsync(id); //  // Generic

            // return new  ProductToRetuenDto {
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     PictureUrl = product.PictureUrl,
            //     Price = product.Price,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name
            // };
            var spec = new ProductWithTypesAndBrctorandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToRetuenDto>(product);

        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand(){
            // var brands =  await _repo.GteProductBrandsAsync();
            var brands =  await _productBrandRepo.ListAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType(){
            // var types =  await _repo.GteProductTypesAsync();
            var types =  await _productTypeRepo.ListAllAsync();
            return Ok(types);
        }
     
    }
}