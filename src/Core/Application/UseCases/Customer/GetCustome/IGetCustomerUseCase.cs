using Core.Domain.Entities;

namespace Application.UseCases.Customer.GetCustome
{
    public interface IGetCustomerUseCase
    {
        Customer GetCustomerByCpf(string customerCpf);
    }
}
