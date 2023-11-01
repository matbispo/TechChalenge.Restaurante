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

        public void CreateProduct(Product product)
        {
            _productRepository.CreateProduct(product);
        }

        public void DeleteProduct(long productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        public IList<Product?> GetProductByCategory(ProductCategory ProductCategoty)
        {
            return _productRepository.GetProductByCategory(ProductCategoty);
        }

        //public Product? GetProductById(long productId)
        //{
        //    return _productRepository.GetProductById(productId);
        //}

        public void UpdateProduct(long productId, Product product)
        {
            _productRepository.UpdateProduct(productId, product);
        }
    }
}
