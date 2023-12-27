namespace Shipping.OrdersHub.Domain.Entities;

public abstract class EntityBase
{
	protected EntityBase()
	{
		Id = Guid.NewGuid();
	}

	public Guid Id { get; private set; }
}