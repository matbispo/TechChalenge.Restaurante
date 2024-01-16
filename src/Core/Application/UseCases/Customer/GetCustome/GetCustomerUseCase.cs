
using Domain.Interfaces.Gateways;

namespace Application.UseCases.Customer.GetCustome
{
    public class GetCustomerUseCase : IGetCustomerUseCase
    {
        private readonly IGetCustomerByCPFGateway _getCustomerByCPFGateway;

        public GetCustomerUseCase(IGetCustomerByCPFGateway getCustomerByCPFGateway)
        {
            _getCustomerByCPFGateway = getCustomerByCPFGateway;
        }

        public Domain.Entities.Customer GetCustomerByCpf(string customerCpf)
        {
            return _getCustomerByCPFGateway.GetCustomerByCpf(customerCpf);
        }
    }
}
