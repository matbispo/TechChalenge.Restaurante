using Core.Domain.Entities;

namespace Domain.Interfaces.Gateways
{
    public interface ICreateCustomerGateway
    {
        long CreateUser(Customer customer);
    }
}
