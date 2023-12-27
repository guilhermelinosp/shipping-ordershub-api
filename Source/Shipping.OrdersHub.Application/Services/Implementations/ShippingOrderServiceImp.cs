using Shipping.OrdersHub.Application.Models.InputModels;
using Shipping.OrdersHub.Application.Models.ViewModels;
using Shipping.OrdersHub.Domain.Repositories;

namespace Shipping.OrdersHub.Application.Services.Implementations;

public class ShippingOrderServiceImp : IShippingOrderService
{
	private readonly IShippingOrderRepository _repository;

	public ShippingOrderServiceImp(IShippingOrderRepository repository)
	{
		_repository = repository;
	}

	public async Task<string> Add(AddShippingOrderInputModel model)
	{
		var shippingOrder = model.ToEntity();
		var shippingServices = model
			.Services
			.Select(s => s.ToEntity())
			.ToList();

		shippingOrder.SetupServices(shippingServices);

		await _repository.AddAsync(shippingOrder);

		return shippingOrder.TrackingCode;
	}

	public async Task<ShippingOrderViewModel> GetByCode(string trackingCode)
	{
		var shippingOrder = await _repository.GetByCodeAsync(trackingCode);

		return ShippingOrderViewModel.FromEntity(shippingOrder);
	}
}