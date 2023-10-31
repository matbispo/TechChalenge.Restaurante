
using Domain.ValueObjects;

namespace Domain.Entities
{
    public record Product
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProductCategory Category { get; set; }
        public decimal Price { get; set; }
    }
}
