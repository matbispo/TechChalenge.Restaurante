﻿using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(Product product);

        //Product? GetProductById(long productId);

        IList<Product?> GetProductByCategory(ProductCategory ProductCategoty);
        void UpdateProduct(long productId, Product product);

        void DeleteProduct(long productId);
    }
}