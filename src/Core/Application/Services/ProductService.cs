using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Services
{
    internal class ProductService : IProductService
    {
        private readonly IproductRepository _productRepository;

        public ProductService(IproductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public long CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public void DeleteProduct(long productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        public IList<Product?> GetProductByCategory(ProductCategory ProductCategoty)
        {
            return _productRepository.GetProductByCategory(ProductCategoty);
        }

        public void UpdateProduct(long productId, Product product)
        {
            _productRepository.UpdateProduct(productId, product);
        }
    }
}
