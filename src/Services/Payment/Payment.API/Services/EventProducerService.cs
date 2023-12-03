using System.Text;
using Inveon.eCommerceExample.Payment.API.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Inveon.eCommerceExample.Payment.API.Services;

public class EventProducerService : IEventProducerService
{
    private readonly string _hostName;
    private readonly string _queueName;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public EventProducerService()
    {
        _hostName = "event-bus";
        _queueName = "order-queue";

        var factory = new ConnectionFactory { HostName = _hostName, UserName = "retrair", Password = "12345" };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: "order-queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );
    }

    public void Produce(OrderMessage orderMessage)
    {
        var message = JsonConvert.SerializeObject(orderMessage);
        var body = Encoding.UTF8.GetBytes(message);

        Console.WriteLine(body);
        _channel.BasicPublish(
            exchange: string.Empty,
            routingKey: "order-queue",
            basicProperties: null,
            body: body
        );
    }
}