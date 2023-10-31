using Domain.Entities;

namespace Domain.Aplication
{
    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);
        Customer GetCustomerByCpf(string customerCpf);
    }
}
