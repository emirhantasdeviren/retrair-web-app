using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Inveon.eCommerceExample.Order.API.BackgroundServices;

public class EventConsumerService : BackgroundService
{
    private readonly string _hostName;
    private readonly string _queueName;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public EventConsumerService()
    {
        _hostName = "event_bus";
        _queueName = "order_queue";

        var factory = new ConnectionFactory { HostName = _hostName, DispatchConsumersAsync = true };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    private async Task ReceivedAsync(object? model, BasicDeliverEventArgs ea)
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        Console.WriteLine($"Received message: {message}");

        _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

        await Task.Yield();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += ReceivedAsync;

        _channel.BasicConsume(queue: _queueName, autoAck: false, consumer);

        return Task.CompletedTask;
    }
}