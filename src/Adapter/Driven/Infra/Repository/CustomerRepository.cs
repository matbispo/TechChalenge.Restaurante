
using Domain.Entities;
using Domain.Repositories;

namespace Infra.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        public void CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer? GetCustomerByCpf(string customerCpf)
        {
            throw new NotImplementedException();
        }
    }
}
