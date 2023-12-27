using MongoDB.Driver;
using Shipping.OrdersHub.Domain.Entities;
using Shipping.OrdersHub.Domain.Repositories;

namespace Shipping.OrdersHub.Infrastructure.Persistence.Repositories
{
    public class ShippingServiceRepositoryImp : IShippingServiceRepository
    {
        private readonly IMongoCollection<ShippingService> _collection;

        public ShippingServiceRepositoryImp(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shipping-services");
        }

        public async Task<List<ShippingService>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }
    }
}