using GenericHelper.Core.Model;

namespace Demo.Core.Specification
{
    public class ProductSpecParams :BaseSpecParams
    {
        public int? BrandId { get; set; }
        public string TypeId { get; set; }
        
    }
}