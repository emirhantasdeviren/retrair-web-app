using AutoMapper;
using Inveon.eCommerceExample.Payment.API.Models;
using Inveon.eCommerceExample.Payment.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inveon.eCommerceExample.Payment.API.Controllers;

[ApiController]
[Route("/api/v1/payment")]
public class PaymentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IIyzipayService _iyzipay;
    private readonly IEventProducerService _eventProducerService;

    public PaymentController(IMapper mapper, IIyzipayService iyzipay, IEventProducerService eventProducerService)
    {
        _mapper = mapper;
        _iyzipay = iyzipay;
        _eventProducerService = eventProducerService;
    }

    [HttpPost]
    public IActionResult CreatePayment([FromBody] PaymentDetails paymentDetails)
    {
        var paymentRequest =
            _mapper.Map<Iyzipay.Request.CreatePaymentRequest>(paymentDetails);
        var payment = _iyzipay.CreatePayment(paymentRequest);

        if (payment.Status == "failure")
        {
            return StatusCode(StatusCodes.Status500InternalServerError, payment);
        }
        else
        {
            var itemTransactions = new List<ItemMessage>();
            foreach (var i in payment.PaymentItems) {
                itemTransactions.Add(new ItemMessage {
                    ItemId = Guid.Parse(i.ItemId),
                    PaymentTransactionId = i.PaymentTransactionId,
                    PaidPrice = Convert.ToDouble(i.PaidPrice),
                });
            }
            var orderMessage = new OrderMessage
            {
                PaymentId = payment.PaymentId,
                PaidPrice = paymentDetails.PaidPrice,
                UserId = paymentDetails.Buyer.Id,
                ShippingAddress = paymentDetails.ShippingAddress,
                BillingAddress = paymentDetails.BillingAddress,
                ItemTransactions = itemTransactions,
            };

            _eventProducerService.Produce(orderMessage);
            return Ok(payment);
        }
    }
}
