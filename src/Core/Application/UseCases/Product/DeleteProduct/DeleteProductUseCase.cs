
using Domain.Interfaces.Gateways.Product;

namespace Application.UseCases.Product.DeleteProduct
{
    internal class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IDeleteProductGateway _deleteProductGateway;

        public DeleteProductUseCase(IDeleteProductGateway deleteProductGateway)
        {
            _deleteProductGateway = deleteProductGateway;
        }

        public void DeleteProduct(long productId)
        {
            _deleteProductGateway.Delete(productId);
        }
    }
}
