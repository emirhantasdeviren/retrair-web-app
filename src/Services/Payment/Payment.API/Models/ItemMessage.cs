namespace Inveon.eCommerceExample.Payment.API.Models;

public class ItemMessage
{
    public Guid ItemId { get; set; }
    public required string PaymentTransactionId { get; set; }
    public double PaidPrice { get; set; }
}