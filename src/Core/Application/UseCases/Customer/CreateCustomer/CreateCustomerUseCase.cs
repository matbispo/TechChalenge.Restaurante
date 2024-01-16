
using Domain.Interfaces.Gateways;

namespace Application.UseCases.Customer.CreateCustomer
{
    internal class CreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICreateCustomerGateway _createCustomerGateway;

        public CreateCustomerUseCase(ICreateCustomerGateway createCustomerGateway)
        {
            _createCustomerGateway = createCustomerGateway;
        }

        public long CreateCustomer(Domain.Entities.Customer customer)
        {
            // validar usuario

            return _createCustomerGateway.CreateCustomer(customer);
        }
    }
}
