using MongoDB.Driver;
using ShippingOrders.Core.Entities;
using ShippingOrders.Core.Repositories;

namespace ShippingOrders.Infrastructure.Persistence.Repositories
{
    public class ShippingOrderRepositoryImp : IShippingOrderRepository
    {
        private readonly IMongoCollection<ShippingOrder> _collection;

        public ShippingOrderRepositoryImp(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingOrder>("shipping-orders");
        }

        public async Task<ShippingOrder> GetOrderByCodeAsync(string code)
        {
            return await _collection.Find(c => c.TrackingCode == code).FirstOrDefaultAsync();
        }

        public async Task AddOrderAsync(ShippingOrder order)
        {
            await _collection.InsertOneAsync(order);
        }
    }
}