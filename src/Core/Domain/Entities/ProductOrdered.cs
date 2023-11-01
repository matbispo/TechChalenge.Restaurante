
namespace Domain.Entities
{
    public class ProductOrdered
    {
        public long ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public Guid OrderedId { get; set; }
        public virtual Ordered? Order { get; set; }
    }
}
