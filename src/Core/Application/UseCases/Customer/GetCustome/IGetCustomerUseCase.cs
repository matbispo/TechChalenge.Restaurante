
namespace Application.UseCases.Customer.GetCustome
{
    public interface IGetCustomerUseCase
    {
        Domain.Entities.Customer GetCustomerByCpf(string customerCpf);
    }
}
