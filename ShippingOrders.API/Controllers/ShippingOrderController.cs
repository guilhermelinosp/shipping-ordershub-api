using Microsoft.AspNetCore.Mvc;
using ShippingOrders.Application.InputModels;
using ShippingOrders.Application.Services;

namespace ShippingOrders.API.Controllers
{
    [ApiController]
    [Route("api/shipping-orders")]
    public class ShippingOrdersController : ControllerBase
    {
        private readonly IShippingOrderService _service;

        public ShippingOrdersController(IShippingOrderService service)
        {
            _service = service;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var shippingOrder = await _service.GetOrderByCodeAsync(code)!;

            if (shippingOrder == null!) return NotFound();

            return Ok(shippingOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddShippingOrderInputModel model)
        {
            var code = await _service.AddOrderAsync(model);

            return CreatedAtAction(nameof(GetByCode), new { code }, model);
        }
    }
}