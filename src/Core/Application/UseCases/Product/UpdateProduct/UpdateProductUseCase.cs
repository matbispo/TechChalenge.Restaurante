
using Domain.Interfaces.Gateways.Product;

namespace Application.UseCases.Product.UpdateProduct
{
    internal class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IUpdateProductGateway _gateway;

        public void UpdateProduct(long productId, Domain.Entities.Product product)
        {
            _gateway.UpdateProduct(productId, product);
        }
    }
}
