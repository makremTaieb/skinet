using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    // [Route("api/[controller]")]
    public class ProductsController : BaseApiController
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
        public async  Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GteProducts()
        {
            // var products = await _repo.GteProductsAsync();
            // var products = await _productRepo.ListAllAsync(); // Generic
            // var products = await _productRepo.ListAsync(spec); // Generic with specification 
            // return products.Select(product => new ProductToReturnDto {
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
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse) ,StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GteProduct(int id)
        {
            // return await _repo.GetProductByIdAsync(id);
            // return await _productRepo.GetByIdAsync(id); //  // Generic

            // return new  ProductToReturnDto {
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
            if (product == null) return NotFound(new  ApiResponse(404));
            return _mapper.Map<Product, ProductToReturnDto>(product);

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