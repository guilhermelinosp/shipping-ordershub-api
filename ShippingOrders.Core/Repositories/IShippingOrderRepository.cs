using ShippingOrders.Core.Entities;

namespace ShippingOrders.Core.Repositories
{
    public interface IShippingOrderRepository
    {
        Task<ShippingOrder> GetByCodeAsync(string code);

        Task AddAsync(ShippingOrder shippingOrder);

        Task UpdateAsync(ShippingOrder shippingOrder);
    }
}