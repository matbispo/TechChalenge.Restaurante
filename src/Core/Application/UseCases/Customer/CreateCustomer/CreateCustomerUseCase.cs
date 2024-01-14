
namespace Application.UseCases.Customer.CreateCustomer
{
    internal class CreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICreateCustomerGateway createCustomerGateway;

        public CreateCustomerUseCase(ICreateCustomerGateway createCustomerGateway)
        {
            this.createCustomerGateway = createCustomerGateway;
        }

        public long CreateCustomer(Customer customer)
        {
            // validar usuario

            return createCustomerGateway.CreateCustomer(customer);
        }
    }
}
