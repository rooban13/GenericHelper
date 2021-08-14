using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Core.Specification;
using GenericHelper.Core.Interface;
using GenericHelper.Core.Model;
using GenericHelper.Demo.Core.Entities;
using GenericHelper.Demo.Core.Interface;
using GenericHelper.Demo.Core.Model.Dto;
using GenericHelper.Demo.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericHelper.Demo.Controllers
{
    public class ProductsController : BaseApiController<Product, IProductService, ProductSpecParams,ProductToReturnDto,int>
    {
        public ProductsController(IProductService service ) : base(service )
        {
        }
    }
}