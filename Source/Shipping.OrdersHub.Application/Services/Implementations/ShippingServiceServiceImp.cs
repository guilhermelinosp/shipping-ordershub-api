using Shipping.OrdersHub.Application.Models.ViewModels;
using Shipping.OrdersHub.Domain.Repositories;

namespace Shipping.OrdersHub.Application.Services.Implementations
{
    public class ShippingServiceServiceImp : IShippingServiceService
    {
        private readonly IShippingServiceRepository _repository;

        public ShippingServiceServiceImp(IShippingServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ShippingServiceViewModel>> GetAll()
        {
            var shippingServices = await _repository.GetAllAsync();

            return shippingServices
                .Select(s => new ShippingServiceViewModel(s.Id, s.Title, s.PricePerKg, s.FixedPrice))
                .ToList();
        }
    }
}