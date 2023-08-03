namespace ShippingOrders.Application.ViewModels
{
    public class ShippingServiceViewModel
    {
        public ShippingServiceViewModel(Guid id, string title, decimal priceKg, decimal priceFixed)
        {
            Id = id;
            Title = title;
            PriceKg = priceKg;
            PriceFixed = priceFixed;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public decimal PriceKg { get; private set; }
        public decimal PriceFixed { get; private set; }
    }
}