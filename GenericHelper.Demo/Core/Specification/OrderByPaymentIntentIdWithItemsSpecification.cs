using GenericHelper.Core;
using GenericHelper.Demo.Core.Entities.OrderAggregate;
using System;
using System.Linq.Expressions;

namespace Demo.Core.Specification
{
    public class OrderByPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId) 
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}