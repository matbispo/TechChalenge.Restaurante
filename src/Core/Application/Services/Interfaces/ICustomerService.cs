using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface ICustomerService
    {
        long CreateCustomer(Customer customer);
        Customer GetCustomerByCpf(string customerCpf);
    }
}
