using Core.Domain.Entities;

namespace Application.UseCases.Customer.CreateCustomer
{
    public interface ICreateCustomerUseCase
    {
        long CreateCustomer(Customer customer);
    }
}
