using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IproductRepository
    {
        long CreateProduct(Product product);

        IList<Product?> GetProductByCategory(ProductCategory ProductCategoty);
        void UpdateProduct(long productId, Product product);

        void DeleteProduct(long productId);
    }
}
