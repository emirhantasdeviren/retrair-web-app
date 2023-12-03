namespace Inveon.eCommerceExample.Order.API.Models;

public class Item
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required Guid ItemId { get; set; }
    public required string PaymentId { get; set; }
    public double PaidPrice { get; set; }


    public Guid OderId { get; set; }
    public Order Order { get; set; } = null!;
}