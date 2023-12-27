using Shipping.OrdersHub.Domain.Entities;

namespace Shipping.OrdersHub.Application.Models.InputModels;

public class AddShippingOrderInputModel
{
	public string Description { get; set; }
	public decimal WeightInKg { get; set; }
	public DeliveryAddressInputModel DeliveryAddress { get; set; }
	public List<ShippingServiceInputModel> Services { get; set; }

	public ShippingOrder ToEntity()
	{
		return new ShippingOrder(
			Description,
			WeightInKg,
			DeliveryAddress.ToValueObject()
		);
	}
}