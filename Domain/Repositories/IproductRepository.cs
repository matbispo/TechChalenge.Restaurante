using Domain.Entities;

namespace Domain.Repositories
{
    public interface IproductRepository
    {
        void CreateProduct(Product product);

        Product? GetProductById(long productId);

        IList<Product?> GetProductByCategory(long ProductCategoty);
        Product? UpdateProduct(Product product);

        void DeleteProduct(long productId);
    }
}
