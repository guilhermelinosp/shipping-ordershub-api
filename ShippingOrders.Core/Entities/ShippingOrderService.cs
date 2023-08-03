namespace ShippingOrders.Core.Entities
{
    public class ShippingOrderService : Base
    {
        public ShippingOrderService(string title, decimal price) : base()
        {
            Title = title;
            Price = price;
        }

        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}