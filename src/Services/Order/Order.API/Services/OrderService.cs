
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

    public bool AddOrder(OrderMessage orderMessage)
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

            foreach (var i in orderMessage.ItemTransactions)
            {
                order.Items.Add(new Item
                {
                    ItemId = i.ItemId,
                    PaidPrice = i.PaidPrice,
                    PaymentId = i.PaymentTransactionId,
                    OderId = order.Id,
                });
            }

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}