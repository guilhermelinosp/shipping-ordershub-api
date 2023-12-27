using Microsoft.Extensions.DependencyInjection;
using Shipping.OrdersHub.Application.Services;
using Shipping.OrdersHub.Application.Services.Implementations;
using Shipping.OrdersHub.Application.Subscribers;
using Shipping.OrdersHub.Infrastructure;

namespace Shipping.OrdersHub.Application
{
    public static class ApplicationInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices()
                .AddSubscribers()
                .AddInfrastructureInjection();
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderService, ShippingOrderServiceImp>();
            services.AddScoped<IShippingServiceService, ShippingServiceServiceImp>();

            return services;
        }

        private static IServiceCollection AddSubscribers(this IServiceCollection services)
        {
            services.AddHostedService<ShippingOrderCompletedSubscriber>();

            return services;
        }
    }
}