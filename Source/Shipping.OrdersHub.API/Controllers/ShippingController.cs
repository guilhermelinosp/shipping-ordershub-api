using Microsoft.AspNetCore.Mvc;
using Shipping.OrdersHub.Application.Models.InputModels;
using Shipping.OrdersHub.Application.Models.ViewModels;
using Shipping.OrdersHub.Application.Services;

namespace Shipping.OrdersHub.API.Controllers;

[ApiController]
[Route("api/")]
public class ShippingController(IShippingService service) : ControllerBase
{
	[HttpPost("shipping-orders")]
	public async Task<ActionResult<ShippingOrderViewModel>> Post(AddShippingOrderInputModel model)
	{
		var code = await service.Add(model);

		var shippingOrder = await service.GetByCode(code);

		return Ok(new { message = "Shipping order created successfully", shippingOrder });
	}

	[HttpGet("shipping-services")]
	public async Task<IActionResult> GetAll()
	{
		var shippingServices = await service.GetAll();

		return Ok(shippingServices);
	}
}