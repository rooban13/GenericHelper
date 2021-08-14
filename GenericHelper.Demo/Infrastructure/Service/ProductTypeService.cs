using AutoMapper;
using GenericHelper.Core.Interface;
using GenericHelper.Core.Model;
using GenericHelper.Demo.Core.Entities;
using GenericHelper.Demo.Core.Interface;
using GenericHelper.Service;

namespace GenericHelper.Demo.Infrastructure.Service
{
    public class ProductTypeService : GenericService<ProductType, IGenericRepository<ProductType,string>, BaseSpecParams, ProductType,string>, IProductTypeService
    {
        public ProductTypeService(IGenericRepository<ProductType,string> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
