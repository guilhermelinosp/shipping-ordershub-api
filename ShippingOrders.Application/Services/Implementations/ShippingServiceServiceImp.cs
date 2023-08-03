using ShippingOrders.Application.ViewModels;
using ShippingOrders.Core.Repositories;

namespace ShippingOrders.Application.Services.Implementations
{
    public class ShippingServiceServiceImp : IShippingServiceService
    {
        private readonly IShippingServiceRepository _repository;

        public ShippingServiceServiceImp(IShippingServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ShippingServiceViewModel>> GetAllServicesAsync()
        {
            var shippingServices = await _repository.GetAllServicesAsync();

            return shippingServices
                .Select(s => new ShippingServiceViewModel(s.Id, s.Title, s.PriceKg, s.PriceFixed))
                .ToList();
        }
    }
}