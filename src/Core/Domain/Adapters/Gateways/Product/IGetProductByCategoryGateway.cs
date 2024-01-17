
using Domain.ValueObjects;

namespace Domain.Interfaces.Gateways.Product
{
    public interface IGetProductByCategoryGateway
    {
        IList<Domain.Entities.Product?> GetProductByCategory(ProductCategory ProductCategoty);
    }
}
