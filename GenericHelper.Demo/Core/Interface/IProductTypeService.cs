using GenericHelper.Core.Interface;
using GenericHelper.Core.Model;
using GenericHelper.Demo.Core.Entities;

namespace GenericHelper.Demo.Core.Interface
{
    public interface IProductTypeService : IGenericService<ProductType, BaseSpecParams, ProductType,string>
    {

    }
}
