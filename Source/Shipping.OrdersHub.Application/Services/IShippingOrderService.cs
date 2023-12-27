using Shipping.OrdersHub.Application.Models.InputModels;
using Shipping.OrdersHub.Application.Models.ViewModels;

namespace Shipping.OrdersHub.Application.Services
{
    public interface IShippingOrderService
    {
        Task<string> Add(AddShippingOrderInputModel model);

        Task<ShippingOrderViewModel> GetByCode(string trackingCode);
    }
}