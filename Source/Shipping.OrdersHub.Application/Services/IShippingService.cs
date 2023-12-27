using Shipping.OrdersHub.Application.Models.InputModels;
using Shipping.OrdersHub.Application.Models.ViewModels;

namespace Shipping.OrdersHub.Application.Services;

public interface IShippingService
{
	Task<string> Add(AddShippingOrderInputModel model);

	Task<ShippingOrderViewModel> GetByCode(string trackingCode);
	
	Task<List<ShippingServiceViewModel>> GetAll();
}