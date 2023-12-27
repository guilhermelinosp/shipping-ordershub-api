using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shipping.OrdersHub.Domain.Repositories;
using System.Text;
using Microsoft.Extensions.Configuration;
using Shipping.OrdersHub.Application.Events;

namespace Shipping.OrdersHub.Application.Subscribers;

public class ShippingOrderSubscriber : BackgroundService
{
	private readonly IModel _channel;
	private const string Queue = "shipping-orders-service/shipping-order-completed";
	private const string RoutingKeySubscribe = "shipping-order-completed";
	private readonly IServiceProvider _serviceProvider;
	private const string TrackingsExchange = "trackings-service";

	public ShippingOrderSubscriber(IServiceProvider serviceProvider, IConfiguration configuration)
	{
		var connectionFactory = new ConnectionFactory
		{
			HostName = configuration["RabbitMQ_HostName"],
			UserName = configuration["RabbitMQ_UserName"],
			Password = configuration["RabbitMQ_Password"]
		};

		var connection = connectionFactory.CreateConnection("shipping-order-completed-consumer");

		_channel = connection.CreateModel();

		_channel.QueueDeclare(
			Queue,
			true,
			false,
			false);

		_channel.QueueBind(Queue, TrackingsExchange, RoutingKeySubscribe);

		_serviceProvider = serviceProvider;
	}

	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		var consumer = new EventingBasicConsumer(_channel);

		consumer.Received += (sender, eventArgs) =>
		{
			var contentArray = eventArgs.Body.ToArray();
			var contentString = Encoding.UTF8.GetString(contentArray);
			var @event = JsonConvert.DeserializeObject<ShippingOrderCompletedEvent>(contentString);

			Console.WriteLine($"Message ShippingOrderCompletedEvent received with Code {@event!.TrackingCode}");

			Complete(@event).Wait(stoppingToken);

			_channel.BasicAck(eventArgs.DeliveryTag, false);
		};

		_channel.BasicConsume(Queue, false, consumer);

		return Task.CompletedTask;
	}

	private async Task Complete(ShippingOrderCompletedEvent @event)
	{
		using var scope = _serviceProvider.CreateScope();
		var repository = scope.ServiceProvider.GetRequiredService<IShippingRepository>();
		var shippingOrder = await repository.GetByCodeAsync(@event.TrackingCode!);
		shippingOrder.SetCompleted();
		await repository.UpdateAsync(shippingOrder);
	}
}