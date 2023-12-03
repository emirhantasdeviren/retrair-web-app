namespace Inveon.eCommerceExample.Order.API.Models;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string PaymentId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeliveredAt { get; set; }
    public DateTime? CanceledAt { get; set; }
    public DateTime? RefundedAt { get; set; }
    public required Guid UserId { get; set; }
    public required Address ShippingAddress { get; set; }
    public required Address BillingAddress { get; set; }
    public double PaidPrice { get; set; }

    public List<Item> Items { get; set; } = new List<Item>();
}