using AutoMapper;
using GenericHelper.Core.Interface;
using GenericHelper.Core.Model;
using GenericHelper.Demo.Core.Entities;
using GenericHelper.Demo.Core.Interface;
using GenericHelper.Service;
using System;

namespace GenericHelper.Demo.Infrastructure.Service
{
    public class CustomerService : GenericService<Customer, IGenericRepository<Customer, Guid>, BaseSpecParams, Customer, Guid>, ICustomerService
    {
        public CustomerService(IGenericRepository<Customer, Guid> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
