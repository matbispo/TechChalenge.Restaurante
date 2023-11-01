using Domain.ValueObjects;

namespace Domain.Entities
{
    public record Customer
    {
        public long CustomerId { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }
        public string Cpf { get; set; }

        //public virtual IList<Order> Orders { get; set; }

        //public Customer()
        //{
        //    Orders = new List<Order>();
        //}
    }
}
