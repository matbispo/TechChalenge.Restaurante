using Domain.Interfaces.Gateways.Product;
using Domain.ValueObjects;

namespace Application.UseCases.Product.GetProductByCategory
{
    internal class GetProductByCategoryUseCase : IGetProductByCategoryUseCase
    {
        private readonly IGetProductByCategoryGateway getProductByCategotyGateway;

        public GetProductByCategoryUseCase(IGetProductByCategoryGateway getProductByCategotyGateway)
        {
            this.getProductByCategotyGateway = getProductByCategotyGateway;
        }

        public IList<Domain.Entities.Product?> GetProductByCategory(ProductCategory ProductCategoty)
        {
            return getProductByCategotyGateway.Get();
        }
    }
}
