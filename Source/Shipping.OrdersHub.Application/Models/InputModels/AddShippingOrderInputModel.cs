using Shipping.OrdersHub.Domain.Entities;
using Shipping.OrdersHub.Domain.ValueObjects;

namespace Shipping.OrdersHub.Application.Models.InputModels
{
    public class AddShippingOrderInputModel
    {
        public string Description { get; set; }
        public decimal WeightInKg { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }
        public List<ShippingServiceInputModel> Services { get; set; }

        public ShippingOrder ToEntity()
            => new(
                Description,
                WeightInKg,
                DeliveryAddress.ToValueObject()
            );
    }

    public class DeliveryAddressInputModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ContactEmail { get; set; }

        public DeliveryAddress ToValueObject() => new(Street, Number, ZipCode, City, State, Country, ContactEmail);
    }

    public class ShippingServiceInputModel
    {
        public string Title { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal FixedPrice { get; set; }

        public ShippingService ToEntity() => new(Title, PricePerKg, FixedPrice);
    }
}