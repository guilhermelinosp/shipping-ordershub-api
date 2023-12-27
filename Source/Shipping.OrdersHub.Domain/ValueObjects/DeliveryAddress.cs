namespace Shipping.OrdersHub.Domain.ValueObjects
{
    public record DeliveryAddress(string Street, string Number, string ZipCode, string City, string State,
        string Country, string ContactEmail)
    {
    }
}