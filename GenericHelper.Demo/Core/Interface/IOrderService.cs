using GenericHelper.Demo.Core.Entities;
using GenericHelper.Demo.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericHelper.Demo.Core.Interface
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, Address shippingAddress);
        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
    }
}
