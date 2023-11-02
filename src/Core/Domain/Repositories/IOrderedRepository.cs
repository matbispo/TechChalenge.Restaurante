
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderedRepository
    {
        public string? CreateOrder(Ordered ordered);

        public IEnumerable<Ordered> GetAll();
    }
}
