using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Order
    {
        public Customer? Customer { get; set; }

        public IList<Product> Products { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
