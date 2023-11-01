using Domain.ValueObjects;

namespace Domain.Entities
{
    public record Ordered
    {
        public Guid OrderedId {  get; set; }
        public DateTime RequestDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsActive { get; set; }
    //    public long CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual IList<Product> Products { get; set; }

        public Ordered()
        {
            IsActive = true;
            Products = new List<Product>();
        }
    }
}
