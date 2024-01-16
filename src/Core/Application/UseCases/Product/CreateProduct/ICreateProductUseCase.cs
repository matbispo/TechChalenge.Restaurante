
namespace Application.UseCases.Product.CreateProduct
{
    public interface ICreateProductUseCase
    {
        long CreateProduct(Domain.Entities.Product product);
    }
}
