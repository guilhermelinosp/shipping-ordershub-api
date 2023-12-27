namespace Shipping.OrdersHub.Domain.Entities;

public abstract class Base
{
	public Guid Id { get; private set; } = Guid.NewGuid();
}