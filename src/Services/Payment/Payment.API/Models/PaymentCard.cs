namespace Inveon.eCommerceExample.Payment.API.Models;

public class PaymentCard
{
    public required string CardHolderName { get; set; }
    public required string CardNumber { get; set; }
    public required string ExpireMonth { get; set; }
    public required string ExpireYear { get; set; }
    public required string Cvc { get; set; }
}
