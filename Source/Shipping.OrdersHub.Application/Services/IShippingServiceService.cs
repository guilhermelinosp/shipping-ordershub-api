using Shipping.OrdersHub.Application.Models.ViewModels;

namespace Shipping.OrdersHub.Application.Services
{
    public interface IShippingServiceService
    {
        Task<List<ShippingServiceViewModel>> GetAll();
    }
}