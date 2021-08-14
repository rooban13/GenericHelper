using GenericHelper.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GenericHelper.Core
{
    public class BasePrimaryIdSpecification<T,T2> : BaseSpecification<T>  where T:BaseEntity<T2> 
    {
        public BasePrimaryIdSpecification(T2 id)
            : base(x => x.Id.Equals(id)  )
        {
            
        }
    }
}
