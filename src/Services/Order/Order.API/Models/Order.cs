namespace Inveon.eCommerceExample.Order.API.Models;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string PaymentId { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = new DateTimeOffset(DateTime.UtcNow, new TimeSpan(3, 0, 0));
    public DateTimeOffset? DeliveredAt { get; set; }
    public DateTimeOffset? CanceledAt { get; set; }
    public DateTimeOffset? RefundedAt { get; set; }
    public required Guid UserId { get; set; }
    public required Address ShippingAddress { get; set; }
    public required Address BillingAddress { get; set; }
    public double PaidPrice { get; set; }

    public List<Item> Items { get; set; }
}