using Demo.Core.Specification;
using GenericHelper.Core.Errors;
using GenericHelper.Core.Model;
using GenericHelper.Demo.Core.Entities;
using GenericHelper.Demo.Core.Interface;
using GenericHelper.Demo.Core.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenericHelper.Demo.Controllers
{
    public class ProductTypesController : BaseApiController<ProductType, IProductTypeService, BaseSpecParams, ProductType,string>
    {
        public ProductTypesController(IProductTypeService service) : base(service)
        {
        }

        public override async Task<ActionResult<ProductType>> GetByIdAsync(string id)
        {
           var entity =  await _service.GetByIdAsync(id);

            if (entity != null)
            {
                entity.Name = $"TestOverride {id}";

                return entity;
            }

            if (entity == null) return NotFound(new ApiResponse(404));
            return entity;

        }
    }
}