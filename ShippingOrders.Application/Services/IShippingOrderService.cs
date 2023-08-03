using ShippingOrders.Application.InputModels;
using ShippingOrders.Application.ViewModels;

namespace ShippingOrders.Application.Services
{
    public interface IShippingOrderService
    {
        Task<string> AddOrderAsync(AddShippingOrderInputModel model);

        Task<ShippingOrderViewModel>? GetOrderByCodeAsync(string code);
    }
}