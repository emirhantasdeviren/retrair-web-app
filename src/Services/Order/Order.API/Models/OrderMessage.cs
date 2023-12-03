namespace Inveon.eCommerceExample.Order.API.Models;

public class OrderMessage
{
    public required string PaymentId { get; set; }
    public double PaidPrice { get; set; }
    public required Guid UserId { get; set; }
    public required Address ShippingAddress { get; set; }
    public required Address BillingAddress { get; set; }
    public required List<ItemMessage> ItemTransactions { get; set; }
}