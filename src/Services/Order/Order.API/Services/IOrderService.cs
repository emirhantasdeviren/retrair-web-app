using Inveon.eCommerceExample.Order.API.Models;

namespace Inveon.eCommerceExample.Order.API.Services;

public interface IOrderService
{
    public Task<bool> AddOrder(OrderMessage orderMessage);
}