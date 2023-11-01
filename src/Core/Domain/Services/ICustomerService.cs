using Domain.Entities;

namespace Domain.Aplication
{
    public interface ICustomerService
    {
        long CreateCustomer(Customer customer);
        Customer GetCustomerByCpf(string customerCpf);
    }
}
