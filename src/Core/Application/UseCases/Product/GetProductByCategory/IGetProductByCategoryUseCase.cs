
using Domain.ValueObjects;

namespace Application.UseCases.Product.GetProductByCategory
{
    public interface IGetProductByCategoryUseCase
    {
        IList<Domain.Entities.Product?> GetProductByCategory(ProductCategory ProductCategoty);
    }
}
