using Application.UseCases.Services.Interfaces;
using Core.Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Services
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRespository;

        public CustomerService(ICustomerRepository customerRespository)
        {
            _customerRespository = customerRespository;
        }

        public long CreateCustomer(Customer customer)
        {
            return _customerRespository.CreateCustomer(customer);
        }

        public Customer? GetCustomerByCpf(string customerCpf)
        {
            return _customerRespository.GetCustomerByCpf(customerCpf);
        }
    }
}
