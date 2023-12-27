using MongoDB.Driver;
using Shipping.OrdersHub.Domain.Entities;
using Shipping.OrdersHub.Domain.Repositories;

namespace Shipping.OrdersHub.Infrastructure.Persistence.Repositories;

public class ShippingRepository(IMongoDatabase database) : IShippingRepository
{
	private readonly IMongoCollection<ShippingOrder> _collection = database.GetCollection<ShippingOrder>("shipping-orders");

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
	
	public async Task<List<ShippingService>> GetAllAsync()
	{
		var  collection = database.GetCollection<ShippingService>("shipping-services");

		return await collection.Find(c => true).ToListAsync();
	}
}