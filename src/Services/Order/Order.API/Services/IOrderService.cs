using Inveon.eCommerceExample.Order.API.Models;

namespace Inveon.eCommerceExample.Order.API.Services;

public interface IOrderService
{
    public bool AddOrder(OrderMessage orderMessage);
}