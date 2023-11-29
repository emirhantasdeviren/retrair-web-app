namespace Inveon.eCommerceExample.Carts.API.Models;

public class AddItemRequest
{
    public Guid ProductId { get; set; }

    public AddItemRequest(Guid productId)
    {
        ProductId = productId;
    }
}
