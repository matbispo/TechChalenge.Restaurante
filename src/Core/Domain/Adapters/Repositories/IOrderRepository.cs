using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public string? CreateOrder(Order ordered);

        public IEnumerable<Order> GetAll();
    }
}
