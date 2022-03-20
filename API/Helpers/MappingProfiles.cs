using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateMap<Product , ProductToRetuenDto>(); // "Core.Entities.ProductType",
            CreateMap<Product, ProductToRetuenDto>()
            .ForMember(d => d.ProductBrand , o => o.MapFrom(s => s.ProductBrand.Name ))
            .ForMember(d => d.ProductType , o => o.MapFrom(s => s.ProductType.Name ));  
        }
        
    }
}