using ShippingOrders.Application.Models.InputModels;
using ShippingOrders.Application.Models.ViewModels;

namespace ShippingOrders.Application.Services
{
    public interface IShippingOrderService
    {
        Task<string> Add(AddShippingOrderInputModel model);

        Task<ShippingOrderViewModel> GetByCode(string trackingCode);
    }
}