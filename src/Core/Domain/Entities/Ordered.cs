using Domain.ValueObjects;

namespace Core.Domain.Entities
{
    public class Ordered
    {
        public string? OrderedId {  get; set; }
        public DateTime RequestDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsActive { get; set; }

        public long CustomerId { get; set; }
        public virtual IList<Product> Products { get; set; }

        public Ordered() 
        {
            Products = new List<Product>();
        }

        public Ordered(long customerId)
        {
            OrderedId = Guid.NewGuid().ToString();
            RequestDate = DateTime.Now;
            OrderStatus = OrderStatus.Recebido;
            IsActive = true;
            CustomerId = customerId;
            Products = new List<Product>();
        }

        public void SumTotalPrice() 
        {
            TotalPrice = Products.Sum(x=> x.Price);
        }
    }
}
