using MongoDB.Driver;
using Shipping.OrdersHub.Domain.Entities;

namespace Shipping.OrdersHub.Infrastructure.Persistence
{
    public class DbSeed
    {
        private readonly IMongoCollection<ShippingService> _collection;

        private readonly List<ShippingService> _shippingServices = new()
        {
            new ShippingService("Envio Estadual", 3.75m, 12),
            new ShippingService("Envio Internacional", 5.25m, 15),
            new ShippingService("Caixa tamanho P", 0, 5),
        };

        public DbSeed(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shipping-services");
        }

        public void Populate()
        {
            if (_collection.CountDocuments(c => true) == 0)
                _collection.InsertMany(_shippingServices);
        }
    }
}