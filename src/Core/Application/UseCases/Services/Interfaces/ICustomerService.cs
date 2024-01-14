using Core.Domain.Entities;

namespace Application.UseCases.Services.Interfaces
{
    public interface ICustomerService
    {
        long CreateCustomer(Customer customer);
        Customer GetCustomerByCpf(string customerCpf);
    }
}
