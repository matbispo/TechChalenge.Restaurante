using Application.UseCases.Services;
using Application.UseCases.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
