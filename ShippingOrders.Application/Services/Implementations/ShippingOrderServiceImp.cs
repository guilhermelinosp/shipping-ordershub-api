using ShippingOrders.Application.InputModels;
using ShippingOrders.Application.ViewModels;
using ShippingOrders.Core.Repositories;

namespace ShippingOrders.Application.Services.Implementations
{
    public class ShippingOrderServiceImp : IShippingOrderService
    {
        private readonly IShippingOrderRepository _repository;

        public ShippingOrderServiceImp(IShippingOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> AddOrderAsync(AddShippingOrderInputModel model)
        {
            var shippingOrder = model.ToEntity();
            var shippingServices = model.Services
                .Select(s => s.ToEntity())
                .ToList();

            shippingOrder.SetupServices(shippingServices);

            await _repository.AddOrderAsync(shippingOrder);

            return shippingOrder.TrackingCode;
        }

        public async Task<ShippingOrderViewModel> GetOrderByCodeAsync(string trackingCode)
        {
            var shippingOrder = await _repository.GetOrderByCodeAsync(trackingCode);

            return ShippingOrderViewModel.FromEntity(shippingOrder);
        }
    }
}