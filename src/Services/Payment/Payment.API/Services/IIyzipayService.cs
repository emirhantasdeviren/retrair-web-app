namespace Inveon.eCommerceExample.Payment.API.Services;

public interface IIyzipayService
{
    Iyzipay.Model.Payment CreatePayment(Iyzipay.Request.CreatePaymentRequest createPaymentRequest);
}
