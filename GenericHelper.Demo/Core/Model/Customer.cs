using GenericHelper.Core.Model;
using System;

namespace GenericHelper.Demo.Core.Entities
{
    public class Customer : BaseEntity<Guid>
    {
        public string Name { get; set; }
       
    }
}