using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Order
    {
        public string? OrderedId {  get; set; }
        public DateTime RequestDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsActive { get; set; }

        public long CustomerId { get; set; }
        public virtual IList<Product> Products { get; set; }

        public Order() 
        {
            Products = new List<Product>();
        }

        public Order(long customerId)
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
