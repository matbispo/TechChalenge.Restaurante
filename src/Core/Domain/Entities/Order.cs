using Domain.ValueObjects;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities
{
    public record Order
    {
        public Guid Id {  get; set; }
        public DateTime RequestDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsDeleted { get; set; }
        public long CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual IList<Product> Products { get; set; }

        public Order()
        {
            IsDeleted = false;
            Products = new List<Product>();
        }
    }
}
