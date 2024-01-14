
namespace Domain.Interfaces.Gateways.Order
{
    public interface ICreateOrderGateway
    {
        public IList<Domain.Entities.Product> GetProductsById(IList<long> ids);

        public string? CreateOrder(Domain.Entities.Order order);
    }
}
