
namespace Domain.Interfaces.Gateways
{
    public interface ICreateCustomerGateway
    {
        long CreateCustomer(Domain.Entities.Customer customer);
    }
}
