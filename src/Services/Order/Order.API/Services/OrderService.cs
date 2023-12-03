
using Inveon.eCommerceExample.Order.API.Data;
using Inveon.eCommerceExample.Order.API.Models;

namespace Inveon.eCommerceExample.Order.API.Services;

public class OrderService : IOrderService
{
    private readonly OrderContext _ctx;

    public OrderService(OrderContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<bool> AddOrder(OrderMessage orderMessage)
    {
        try
        {
            var order = new Models.Order
            {
                PaymentId = orderMessage.PaymentId,
                UserId = orderMessage.UserId,
                ShippingAddress = orderMessage.ShippingAddress,
                BillingAddress = orderMessage.BillingAddress,
                PaidPrice = orderMessage.PaidPrice,
            };

            var items = new List<Item>();
            foreach (var i in orderMessage.ItemTransactions)
            {
                items.Add(new Item
                {
                    Id = i.ItemId,
                    PaidPrice = i.PaidPrice,
                    PaymentId = i.PaymentTransactionId,
                    OderId = order.Id,
                    Order = order
                });
            }

            order.Items = items;

            await _ctx.Orders.AddAsync(order);
            await _ctx.Items.AddRangeAsync(items);
            await _ctx.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}