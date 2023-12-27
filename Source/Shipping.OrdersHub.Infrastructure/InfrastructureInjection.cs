using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using Shipping.OrdersHub.Domain.Repositories;
using Shipping.OrdersHub.Infrastructure.Persistence;
using Shipping.OrdersHub.Infrastructure.Persistence.Repositories;

namespace Shipping.OrdersHub.Infrastructure
{
    public static class InfrastructureInjection
    {
        public static void AddInfrastructureInjection(this IServiceCollection services)
        {
            services
                .AddMongo()
                .AddRepositories();
        }

        private static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                var configuration = sp.GetService<IConfiguration>();
                var options = new MongoDbOptions();

                configuration?.GetSection("MongoDb").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp =>
            {
                var options = sp.GetService<MongoDbOptions>();

                var client = new MongoClient(options!.ConnectionString);
                var db = client.GetDatabase(options.Database);

                var dbSeed = new DbSeed(db);
                dbSeed.Populate();

                return client;
            });

            services.AddTransient(sp =>
            {
                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                var db = mongoClient!.GetDatabase(options!.Database);

                return db;
            });

            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderRepository, ShippingOrderRepositoryImp>();
            services.AddScoped<IShippingServiceRepository, ShippingServiceRepositoryImp>();
        }
    }
}