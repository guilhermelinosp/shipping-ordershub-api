namespace ShippingOrders.Core.Entities
{
    public class ShippingService : Base
    {
        public ShippingService(string title, decimal priceKg, decimal priceFixed) : base()
        {
            Title = title;
            PriceKg = priceKg;
            PriceFixed = priceFixed;
        }

        public string Title { get; set; }
        public decimal PriceKg { get; set; }
        public decimal PriceFixed { get; set; }
    }
}