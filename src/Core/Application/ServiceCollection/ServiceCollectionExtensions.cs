using Application.Services;
using Domain.Aplication;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderedService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
