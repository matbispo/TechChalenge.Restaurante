using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infra.Context;

namespace Infra.Repository
{
    internal class ProductRepository : IproductRepository
    {

        public void CreateProduct(Product product)
        {

        }

        public void DeleteProduct(long productId)
        {
            throw new NotImplementedException();
        }

        public IList<Product?>? GetProductByCategory(ProductCategory ProductCategoty)
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
