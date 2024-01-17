
namespace Domain.Interfaces.Gateways.Product
{
    public interface IUpdateProductGateway
    {
        void UpdateProduct(long productId, Domain.Entities.Product product);
    }
}
