using ShippingOrders.Core.Entities;

namespace ShippingOrders.Core.Repositories
{
    public interface IShippingOrderRepository
    {
        Task<ShippingOrder> GetOrderByCodeAsync(string code);

        Task AddOrderAsync(ShippingOrder order);
    }
}