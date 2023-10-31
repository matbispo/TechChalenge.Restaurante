using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IproductRepository
    {
        void CreateProduct(Product product);

        Product? GetProductById(long productId);

        IList<Product?> GetProductByCategory(ProductCategory ProductCategoty);
        Product? UpdateProduct(Product product);

        void DeleteProduct(long productId);
    }
}
