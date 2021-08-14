using System;
using System.Text;

namespace GenericHelper.Core.Model
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }

    }
}
