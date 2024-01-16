
using Domain.Interfaces.Gateways.Product;

namespace Application.UseCases.Product.CreateProduct
{
    internal class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly ICreateProductGateway _createProductGateway;

        public long CreateProduct(Domain.Entities.Product product)
        {
            return _createProductGateway.CreateProduct(product);
        }
    }
}
