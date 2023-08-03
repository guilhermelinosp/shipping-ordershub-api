using ShippingOrders.Core.Enums;
using ShippingOrders.Core.ValueObjects;

namespace ShippingOrders.Core.Entities
{
    public class ShippingOrder : Base
    {
        public ShippingOrder(string description, decimal totalWeight, DeliveryAddress deliveryAddress)
        {
            TrackingCode = GenerateTrackingCode();
            Description = description;
            PostedAt = DateTime.Now;
            TotalWeight = totalWeight;
            DeliveryAddress = deliveryAddress;
            Status = ShippingOrderStatus.Started;
            Services = new List<ShippingOrderService>();
        }

        public string TrackingCode { get; private set; }
        public string Description { get; private set; }
        public DateTime PostedAt { get; private set; }
        public decimal TotalWeight { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; }
        public ShippingOrderStatus Status { get; private set; }
        public decimal TotalPrice { get; private set; }
        public List<ShippingOrderService> Services { get; private set; }

        public void SetupServices(List<ShippingService> services)
        {
            foreach (var service in services)
            {
                var servicePrice = service.PriceFixed + service.PriceKg * TotalWeight;

                TotalPrice += servicePrice;
                Services.Add(new ShippingOrderService(service.Title, servicePrice));
            }
        }

        private string GenerateTrackingCode()
        {
            const string chars = "ABCDEFGHIJKL0123456789MNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var trackingCode = new char[10];
            for (var i = 0; i < 10; i++)
            {
                trackingCode[i] = chars[random.Next(chars.Length)];
            }

            return new string(trackingCode);
        }

        public void SetCompleted()
        {
            Status = ShippingOrderStatus.Delivered;
        }
    }
}