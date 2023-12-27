namespace Shipping.OrdersHub.Application.Subscribers;

public class ShippingOrderIsCompletedEvent
{
	public string? TrackingCode { get; set; }
}