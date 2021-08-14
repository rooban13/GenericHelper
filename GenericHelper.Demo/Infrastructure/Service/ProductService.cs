using AutoMapper;
using Demo.Core.Specification;
using GenericHelper.Core.Interface;
using GenericHelper.Data;
using GenericHelper.Demo.Core.Entities;
using GenericHelper.Demo.Core.Interface;
using GenericHelper.Demo.Core.Model.Dto;
using GenericHelper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericHelper.Demo.Infrastructure.Service
{
    public class ProductService : GenericService<Product, IGenericRepository<Product,int>, ProductSpecParams, ProductToReturnDto,int> ,IProductService
    {
        public ProductService(IGenericRepository<Product,int> repository,  IMapper mapper) : base(repository,mapper)
        {

        }

        public override ISpecification<Product> GetSpecification(ProductSpecParams specParams)
        {
            return new ProductsWithTypesAndBrandsSpecification(specParams);
        }

        public override ISpecification<Product> GetSpecificationForCount(ProductSpecParams specParams)
        {
            return new ProductWithFiltersForCountSpecificication(specParams);
        }

        public override ISpecification<Product> GetSpecificationForGetById(int id)
        {
            return new ProductsWithTypesAndBrandsSpecification(id);
        }
    }
}
