using Newtonsoft.Json;

namespace Inveon.eCommerceExample.Payment.API.Models;

public class PaymentDetails
{
    public string Locale { get; set; } = "tr";
    public double Price { get; set; }
    public double PaidPrice { get; set; }
    public string Currency { get; set; } = "TL";
    public int Installment { get; set; } = 1;
    public Guid CartId { get; set; }
    public string PaymentChannel { get; set; } = "WEB";
    public required PaymentCard PaymentCard { get; set; }
    public required Buyer Buyer { get; set; }
    public required Address ShippingAddress { get; set; }
    public required Address BillingAddress { get; set; }
    public required List<Item> CartItems { get; set; }
}
