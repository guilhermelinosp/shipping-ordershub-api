using MongoDB.Driver;
using Shipping.OrdersHub.Domain.Entities;
using Shipping.OrdersHub.Domain.Repositories;

namespace Shipping.OrdersHub.Infrastructure.Persistence.Repositories;

public class ShippingOrderRepositoryImp : IShippingOrderRepository
{
	private readonly IMongoCollection<ShippingOrder> _collection;

	public ShippingOrderRepositoryImp(IMongoDatabase database)
	{
		_collection = database.GetCollection<ShippingOrder>("shipping-orders");
	}

	public async Task AddAsync(ShippingOrder shippingOrder)
	{
		await _collection.InsertOneAsync(shippingOrder);
	}

	public async Task<ShippingOrder> GetByCodeAsync(string code)
	{
		return await _collection.Find(c => c.TrackingCode == code).SingleOrDefaultAsync();
	}

	public async Task UpdateAsync(ShippingOrder shippingOrder)
	{
		await _collection
			.ReplaceOneAsync(so => so.TrackingCode == shippingOrder.TrackingCode, shippingOrder);
	}
}