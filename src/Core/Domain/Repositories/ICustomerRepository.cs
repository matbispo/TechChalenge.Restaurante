
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Customer? GetCustomerByCpf(string customerCpf);
    }
}
