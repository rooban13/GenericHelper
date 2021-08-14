using GenericHelper.Core.Model;
using GenericHelper.Demo.Core.Entities;
using GenericHelper.Demo.Core.Interface;
using System;

namespace GenericHelper.Demo.Controllers
{
    public class CustomerController : BaseApiController<Customer, ICustomerService, BaseSpecParams, Customer, Guid>
    {
        public CustomerController(ICustomerService service) : base(service)
        {
        }
    }
}