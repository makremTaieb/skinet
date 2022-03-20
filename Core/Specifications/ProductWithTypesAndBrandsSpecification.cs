using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrctorandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrctorandsSpecification()
        {
                AddInclude(p => p.ProductType);
                AddInclude(p => p.ProductBrand);
        }

        public ProductWithTypesAndBrctorandsSpecification(int id) 
                : base(x => x.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}