namespace Shipping.OrdersHub.Application.Events;

public class ShippingOrderCompletedEvent
{
	public string? TrackingCode { get; set; }
}