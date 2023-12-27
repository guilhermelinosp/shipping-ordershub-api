using Shipping.OrdersHub.Domain.Entities;

namespace Shipping.OrdersHub.Application.Models.InputModels;

public class ShippingServiceInputModel
{
	public string Title { get; set; }
	public decimal PricePerKg { get; set; }
	public decimal FixedPrice { get; set; }

	public ShippingService ToEntity()
	{
		return new ShippingService(Title, PricePerKg, FixedPrice);
	}
}