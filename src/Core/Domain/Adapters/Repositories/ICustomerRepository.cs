using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        long CreateCustomer(Customer customer);
        Customer? GetCustomerByCpf(string customerCpf);
    }
}
