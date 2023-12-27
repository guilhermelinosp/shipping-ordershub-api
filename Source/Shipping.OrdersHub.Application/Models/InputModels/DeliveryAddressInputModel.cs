using Shipping.OrdersHub.Domain.ValueObjects;

namespace Shipping.OrdersHub.Application.Models.InputModels;

public class DeliveryAddressInputModel
{
	public string Street { get; set; }
	public string Number { get; set; }
	public string ZipCode { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string Country { get; set; }
	public string ContactEmail { get; set; }

	public DeliveryAddress ToValueObject()
	{
		return new DeliveryAddress(Street, Number, ZipCode, City, State, Country, ContactEmail);
	}
}