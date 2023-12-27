using Shipping.OrdersHub.Domain.Entities;

namespace Shipping.OrdersHub.Domain.Repositories;

public interface IShippingRepository
{
	Task<ShippingOrder> GetByCodeAsync(string code);

	Task AddAsync(ShippingOrder shippingOrder);

	Task UpdateAsync(ShippingOrder shippingOrder);
	
	Task<List<ShippingService>> GetAllAsync();
}