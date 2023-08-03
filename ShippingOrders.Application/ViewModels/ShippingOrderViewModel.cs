using ShippingOrders.Core.Entities;

namespace ShippingOrders.Application.ViewModels
{
    public class ShippingOrderViewModel
    {
        private ShippingOrderViewModel(string trackingCode, string description, DateTime postedAt, decimal totalWeight,
            string fullAddress)
        {
            TrackingCode = trackingCode;
            Description = description;
            PostedAt = postedAt;
            TotalWeight = totalWeight;
            FullAddress = fullAddress;
        }

        public string TrackingCode { get; private set; }
        public string Description { get; private set; }
        public DateTime PostedAt { get; private set; }
        public decimal TotalWeight { get; private set; }
        public string FullAddress { get; private set; }

        public static ShippingOrderViewModel FromEntity(ShippingOrder shippingOrder)
        {
            var address = shippingOrder.DeliveryAddress;

            return new ShippingOrderViewModel(
                shippingOrder.TrackingCode,
                shippingOrder.Description,
                shippingOrder.PostedAt,
                shippingOrder.TotalWeight,
                $"{address.Street}, {address.Number}, {address.ZipCode}, {address.City}, {address.State}, {address.Country}"
            );
        }
    }
}