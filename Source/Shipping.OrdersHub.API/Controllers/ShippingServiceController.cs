using Microsoft.AspNetCore.Mvc;
using Shipping.OrdersHub.Application.Services;

namespace Shipping.OrdersHub.API.Controllers;

[ApiController]
[Route("api/shipping-services")]
public class ShippingServiceController : ControllerBase
{
	private readonly IShippingServiceService _service;

	public ShippingServiceController(IShippingServiceService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var shippingServices = await _service.GetAll();

		return Ok(shippingServices);
	}
}