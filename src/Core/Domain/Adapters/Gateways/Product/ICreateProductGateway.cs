
namespace Domain.Interfaces.Gateways.Product
{
    public interface ICreateProductGateway
    {
        long CreateProduct(Domain.Entities.Product product);
    }
}
