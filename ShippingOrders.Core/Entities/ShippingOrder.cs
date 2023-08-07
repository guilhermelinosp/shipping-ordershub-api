using ShippingOrders.Core.Enums;
using ShippingOrders.Core.ValueObjects;

namespace ShippingOrders.Core.Entities
{
    public class ShippingOrder : EntityBase
    {
        public ShippingOrder(string description, decimal weightInKg, DeliveryAddress deliveryAddress)
        {
            TrackingCode = GenerateTrackingCode();
            Description = description;
            PostedAt = DateTime.Now;
            WeightInKg = weightInKg;
            DeliveryAddress = deliveryAddress;
            Status = ShippingOrderStatus.Started;
            Services = new List<ShippingOrderService>();
        }

        public string TrackingCode { get; private set; }
        public string Description { get; private set; }
        public DateTime PostedAt { get; private set; }
        public decimal WeightInKg { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; }
        public ShippingOrderStatus Status { get; private set; }
        private decimal TotalPrice { get; set; }
        private List<ShippingOrderService> Services { get; set; }

        public void SetupServices(List<ShippingService> services)
        {
            foreach (var service in services)
            {
                var servicePrice = service.FixedPrice + service.PricePerKg * WeightInKg;

                TotalPrice += servicePrice;
                Services.Add(new ShippingOrderService(service.Title, servicePrice));
            }
        }

        private static string GenerateTrackingCode()
        {
            const string chars = "0123456789ABCDEFGHIJK0123456789LMNOPQRSTUVWXYZ0123456789";
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