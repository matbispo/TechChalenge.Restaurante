using Application.UseCases.Customer.CreateCustomer;
using Application.UseCases.Customer.GetCustome;
using Application.UseCases.Order.CreateOrder;
using Application.UseCases.Order.GetAllOrders;
using Application.UseCases.Product.CreateProduct;
using Application.UseCases.Product.DeleteProduct;
using Application.UseCases.Product.GetProductByCategory;
using Application.UseCases.Product.UpdateProduct;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateCustomerUseCase, CreateCustomerUseCase>();
            services.AddScoped<IGetCustomerUseCase, GetCustomerUseCase>();
            services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
            services.AddScoped<IGetAllOrdersUseCase, GetAllOrdersUseCase>();
            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddScoped<IGetProductByCategoryUseCase, GetProductByCategoryUseCase>();
            services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();

            return services;
        }
    }
}
