namespace Inveon.eCommerceExample.Order.API.Models;

public class Item
{
    public required Guid Id { get; set; }
    public required string PaymentId { get; set; }
    public double PaidPrice { get; set; }


    public Guid OderId { get; set; }
    public Order Order { get; set; }
}