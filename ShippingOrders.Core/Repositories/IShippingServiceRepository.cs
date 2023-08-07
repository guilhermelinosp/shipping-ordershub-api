using ShippingOrders.Core.Entities;

namespace ShippingOrders.Core.Repositories
{
    public interface IShippingServiceRepository
    {
        Task<List<ShippingService>> GetAllAsync();
    }
}