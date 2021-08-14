using GenericHelper.Core.Model;

namespace GenericHelper.Demo.Core.Entities
{
    public class ProductType : BaseEntity<string>
    {
        public string Name { get; set; }
    }
}