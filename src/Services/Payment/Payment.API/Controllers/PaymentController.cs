using Inveon.eCommerceExample.Payment.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inveon.eCommerceExample.Payment.API.Controllers;

[ApiController]
[Route("/api/v1/payment")]
public class PaymentController : ControllerBase
{

    [HttpGet]
    public IActionResult Get([FromBody] PaymentDetails payment) {
        return Ok();
    }
}