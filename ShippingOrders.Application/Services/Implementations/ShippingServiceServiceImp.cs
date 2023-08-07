using ShippingOrders.Application.Models.ViewModels;
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

        public async Task<List<ShippingServiceViewModel>> GetAll()
        {
            var shippingServices = await _repository.GetAllAsync();

            return shippingServices
                .Select(s => new ShippingServiceViewModel(s.Id, s.Title, s.PricePerKg, s.FixedPrice))
                .ToList();
        }
    }
}