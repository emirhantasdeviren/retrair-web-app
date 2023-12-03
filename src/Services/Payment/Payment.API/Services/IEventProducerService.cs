using Inveon.eCommerceExample.Payment.API.Models;

namespace Inveon.eCommerceExample.Payment.API.Services;

public interface IEventProducerService
{
    public void Produce(OrderMessage orderMessage);
}