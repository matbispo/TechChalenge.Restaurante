
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProductCategory Category { get; set; }
        public decimal Price { get; set; }
    }
}
