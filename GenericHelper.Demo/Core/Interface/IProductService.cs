using Demo.Core.Specification;
using GenericHelper.Core.Interface;
using GenericHelper.Data;
using GenericHelper.Demo.Core.Entities;
using GenericHelper.Demo.Core.Model.Dto;
using GenericHelper.Service;

namespace GenericHelper.Demo.Core.Interface
{
    public interface IProductService : IGenericService<Product,ProductSpecParams, ProductToReturnDto,int>
    {

    }

}
