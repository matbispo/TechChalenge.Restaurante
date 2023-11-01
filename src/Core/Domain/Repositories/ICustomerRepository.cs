
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        long CreateCustomer(Customer customer);
        Customer? GetCustomerByCpf(string customerCpf);
    }
}
