
namespace Application.UseCases.Product.UpdateProduct
{
    public interface IUpdateProductUseCase
    {
        void UpdateProduct(long productId, Domain.Entities.Product product);
    }
}
