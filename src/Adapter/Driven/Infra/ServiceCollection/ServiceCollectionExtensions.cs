using Domain.Repositories;
using Infra.Context;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IproductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
