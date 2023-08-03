using ShippingOrders.Application.ViewModels;

namespace ShippingOrders.Application.Services
{
    public interface IShippingServiceService
    {
        Task<List<ShippingServiceViewModel>> GetAllServicesAsync();
    }
}