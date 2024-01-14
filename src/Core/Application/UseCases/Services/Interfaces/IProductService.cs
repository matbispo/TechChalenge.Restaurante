using Domain.Entities;
using Domain.ValueObjects;

namespace Application.UseCases.Services.Interfaces
{
    public interface IProductService
    {
        long CreateProduct(Product product);

        IList<Product?> GetProductByCategory(ProductCategory ProductCategoty);
        void UpdateProduct(long productId, Product product);

        void DeleteProduct(long productId);
    }
}
