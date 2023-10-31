using Domain.ValueObjects;

namespace Domain.Entities
{
    public record Order
    {
        public Guid Id {  get; set; }
        public Customer? Customer { get; set; }

        public IList<Product> Products { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime RequestDate { get; set; }

        public bool IsDeleted { get; set; }

        public Order()
        {
            IsDeleted = false;
            Products = new List<Product>();
        }
    }
}
