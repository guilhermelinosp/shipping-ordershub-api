using Microsoft.AspNetCore.Mvc;
using Shipping.OrdersHub.Application.Models.InputModels;
using Shipping.OrdersHub.Application.Services;

namespace Shipping.OrdersHub.API.Controllers;

[ApiController]
[Route("api/shipping-orders")]
public class ShippingOrderController : ControllerBase
{
	private readonly IShippingOrderService _service;

	public ShippingOrderController(IShippingOrderService service)
	{
		_service = service;
	}

	[HttpGet("{code}")]
	public async Task<IActionResult> GetByCode(string code)
	{
		var shippingOrder = await _service.GetByCode(code);

		return Ok(shippingOrder);
	}

	[HttpPost]
	public async Task<IActionResult> Post(AddShippingOrderInputModel model)
	{
		var code = await _service.Add(model);

		return CreatedAtAction(
			nameof(GetByCode),
			new { code },
			model
		);
	}
}