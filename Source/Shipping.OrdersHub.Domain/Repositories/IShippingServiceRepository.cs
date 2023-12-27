using Shipping.OrdersHub.Domain.Entities;

namespace Shipping.OrdersHub.Domain.Repositories
{
    public interface IShippingServiceRepository
    {
        Task<List<ShippingService>> GetAllAsync();
    }
}