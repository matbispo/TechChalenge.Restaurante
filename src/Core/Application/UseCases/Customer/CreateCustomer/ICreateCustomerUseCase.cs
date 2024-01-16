
namespace Application.UseCases.Customer.CreateCustomer
{
    public interface ICreateCustomerUseCase
    {
        long CreateCustomer(Domain.Entities.Customer customer);
    }
}
