using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infra.Context;

namespace Infra.Repository
{
    internal class ProductRepository : IproductRepository
    {
        private readonly TechChallengeDbContext _context;

        public ProductRepository(TechChallengeDbContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(long productId)
        {
            throw new NotImplementedException();
        }

        public IList<Product?>? GetProductByCategory(ProductCategory ProductCategoty)
        {
            return _context.Product.Where(x => x.Category == ProductCategoty).ToList();
        }

        public Product? GetProductById(long productId)
        {
            return _context.Product.Where(x => x.Id == productId).FirstOrDefault();
        }

        public Product? UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
