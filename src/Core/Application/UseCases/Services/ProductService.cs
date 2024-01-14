using Application.UseCases.Services.Interfaces;
using Entity = Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;

namespace Application.UseCases.Services
{
    internal class ProductService : IProductService
    {
        private readonly IproductRepository _productRepository;

        public ProductService(IproductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public long CreateProduct(Entity.Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public void DeleteProduct(long productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        public IList<Entity.Product?> GetProductByCategory(ProductCategory ProductCategoty)
        {
            return _productRepository.GetProductByCategory(ProductCategoty);
        }

        public void UpdateProduct(long productId, Entity.Product product)
        {
            _productRepository.UpdateProduct(productId, product);
        }
    }
}
