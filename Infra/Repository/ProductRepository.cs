using Domain.Entities;
using Domain.Repositories;

namespace Infra.Repository
{
    internal class ProductRepository : IproductRepository
    {
        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(long productId)
        {
            throw new NotImplementedException();
        }

        public IList<Product?> GetProductByCategory(long ProductCategoty)
        {
            throw new NotImplementedException();
        }

        public Product? GetProductById(long productId)
        {
            throw new NotImplementedException();
        }

        public Product? UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
