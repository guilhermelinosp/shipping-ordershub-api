using ShippingOrders.Core.Entities;
using ShippingOrders.Core.ValueObjects;

namespace ShippingOrders.Application.InputModels
{
    public class AddShippingOrderInputModel
    {
        public string Description { get; set; }
        public decimal TotalWeight { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }
        public List<ShippingServiceInputModel> Services { get; set; }

        public ShippingOrder ToEntity()
            => new(
                Description,
                TotalWeight,
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

        public DeliveryAddress ToValueObject()
            => new(Street, Number, ZipCode, City, State, Country, ContactEmail);
    }

    public class ShippingServiceInputModel
    {
        public string Title { get; set; }
        public decimal PriceKg { get; set; }
        public decimal PriceFixed { get; set; }

        public ShippingService ToEntity() => new(Title, PriceKg, PriceFixed);
    }
}