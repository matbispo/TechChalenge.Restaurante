using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Ordered
    {
        public Guid OrderedId {  get; set; }
        public DateTime RequestDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsActive { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual IList<Product> Products { get; set; }

        public Ordered(long customerId)
        {
            OrderedId = Guid.NewGuid();
            RequestDate = DateTime.Now;
            OrderStatus = OrderStatus.Recebido;
            IsActive = true;
            Customer = new Customer { CustomerId = customerId};
            Products = new List<Product>();
        }

        public void SumTotalPrice() 
        {
            TotalPrice = Products.Sum(x=> x.Price);
        }
    }
}
