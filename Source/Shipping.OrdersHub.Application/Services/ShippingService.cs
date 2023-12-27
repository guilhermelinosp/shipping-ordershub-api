using Shipping.OrdersHub.Application.Models.InputModels;
using Shipping.OrdersHub.Application.Models.ViewModels;
using Shipping.OrdersHub.Domain.Repositories;

namespace Shipping.OrdersHub.Application.Services;

public class ShippingService(IShippingRepository repository) : IShippingOrderService
{
	public async Task<string> Add(AddShippingOrderInputModel model)
	{
		var shippingOrder = model.ToEntity();
		var shippingServices = model
			.Services!
			.Select(s => s.ToEntity())
			.ToList();

		shippingOrder.SetupServices(shippingServices);

		await repository.AddAsync(shippingOrder);

		return shippingOrder.TrackingCode;
	}

	public async Task<ShippingOrderViewModel> GetByCode(string trackingCode)
	{
		var shippingOrder = await repository.GetByCodeAsync(trackingCode);

		return ShippingOrderViewModel.FromEntity(shippingOrder);
	}
}