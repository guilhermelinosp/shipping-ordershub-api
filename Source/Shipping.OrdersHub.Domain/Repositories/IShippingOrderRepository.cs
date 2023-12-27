using Shipping.OrdersHub.Domain.Entities;

namespace Shipping.OrdersHub.Domain.Repositories
{
    public interface IShippingOrderRepository
    {
        Task<ShippingOrder> GetByCodeAsync(string code);

        Task AddAsync(ShippingOrder shippingOrder);

        Task UpdateAsync(ShippingOrder shippingOrder);
    }
}