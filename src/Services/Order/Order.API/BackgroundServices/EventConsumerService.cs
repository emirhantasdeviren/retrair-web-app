using System.Text;
using Inveon.eCommerceExample.Order.API.Models;
using Inveon.eCommerceExample.Order.API.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Inveon.eCommerceExample.Order.API.BackgroundServices;

public class EventConsumerService : BackgroundService
{
    private readonly string _hostName;
    private readonly string _queueName;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    public EventConsumerService(IServiceProvider serviceProvider)
    {
        _hostName = "event-bus";
        _queueName = "order-queue";

        var factory = new ConnectionFactory { HostName = _hostName, UserName = "retrair", Password = "12345"};

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(
            queue: "order-queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );
        _serviceProvider = serviceProvider;

        Console.WriteLine("Background service started");
    }

    private void Received(object? model, BasicDeliverEventArgs ea)
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        Console.WriteLine($"Received message: {message}");
        var orderMessage = JsonConvert.DeserializeObject<OrderMessage>(message);
        Console.WriteLine(JsonConvert.SerializeObject(orderMessage, Formatting.Indented));
        using (var scope = _serviceProvider.CreateScope())
        {
            var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
            orderService.AddOrder(orderMessage);
        }

        _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += Received;

        _channel.BasicConsume(queue: _queueName, autoAck: false, consumer);

        return Task.CompletedTask;
    }
}