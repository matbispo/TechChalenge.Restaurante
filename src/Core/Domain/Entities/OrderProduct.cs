
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class OrderProduct
    {
        public long ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
