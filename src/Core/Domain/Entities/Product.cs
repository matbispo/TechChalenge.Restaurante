
using Domain.ValueObjects;

namespace Core.Domain.Entities
{
    public record Product
    {

        public long ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProductCategory Category { get; set; }
        public decimal Price { get; set; }
    }
}
