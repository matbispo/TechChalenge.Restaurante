namespace Domain.Interfaces.Gateways
{
    public interface IGetCustomerByCPFGateway
    {
        Domain.Entities.Customer GetCustomerByCpf(string customerCpf);
    }
}
