using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderedRepository
    {
        public string? CreateOrder(Ordered ordered);

        public IEnumerable<Ordered> GetAll();
    }
}
