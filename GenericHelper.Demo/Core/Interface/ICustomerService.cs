using GenericHelper.Core.Interface;
using GenericHelper.Core.Model;
using GenericHelper.Demo.Core.Entities;
using System;

namespace GenericHelper.Demo.Core.Interface
{
    public interface ICustomerService : IGenericService<Customer, BaseSpecParams, Customer, Guid>
    {

    }
}
