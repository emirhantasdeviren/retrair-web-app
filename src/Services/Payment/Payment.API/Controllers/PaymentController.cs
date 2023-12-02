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

    public PaymentController(IMapper mapper, IIyzipayService iyzipay)
    {
        _mapper = mapper;
        _iyzipay = iyzipay;
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
            return Ok(payment);
        }
    }
}
