namespace Inveon.eCommerceExample.Carts.API.Models;

public class CreateCartRequest
{
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }

    public CreateCartRequest(Guid customerId, Guid productId)
    {
        CustomerId = customerId;
        ProductId = productId;
    }
}
