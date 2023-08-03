using Microsoft.Extensions.DependencyInjection;
using ShippingOrders.Application.Services;
using ShippingOrders.Application.Services.Implementations;

namespace ShippingOrders.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            return services.AddApplicationServices();
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderService, ShippingOrderServiceImp>();
            services.AddScoped<IShippingServiceService, ShippingServiceServiceImp>();

            return services;
        }
    }
}