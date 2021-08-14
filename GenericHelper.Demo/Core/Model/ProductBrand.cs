using GenericHelper.Core.Model;

namespace GenericHelper.Demo.Core.Entities
{
    public class ProductBrand : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}