using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Presenters.Dtos
{
    public class OrderDtoInput
    {
        public long CustomerId { get; set; }
        public virtual IList<long> Products { get; set; }

        //public virtual Customer? Customer { get; set; }
        //public Guid OrderedId { get; private set; }
        //public DateTime RequestDate { get; private set; }
        //public decimal TotalPrice { get; private set; }
        //public OrderStatus OrderStatus { get; private set; }
        //public bool IsActive { get; private set; }

        //public OrderDtoInput()
        //{
        //    OrderedId = Guid.NewGuid();
        //    RequestDate = DateTime.Now;
        //    IsActive = true;
        //    OrderStatus = OrderStatus.Recebido;
        //    Products = new List<long>();
        //}
    }
}
