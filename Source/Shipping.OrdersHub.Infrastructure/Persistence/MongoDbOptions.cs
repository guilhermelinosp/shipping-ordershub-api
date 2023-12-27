namespace Shipping.OrdersHub.Infrastructure.Persistence
{
    public class MongoDbOptions
    {
        public string? ConnectionString { get; set; }
        public string? Database { get; set; }
    }
}