using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos
{
    public record OrderedDtoOutput
    {
        public long CustomerId { get; set; }
        public virtual IList<Product> Products { get; set; }
        public Guid OrderedId { get; set; }
        public DateTime RequestDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}
