namespace Inveon.eCommerceExample.Carts.API.Models;

public class UpdateQuantityRequest
{
    public int Quantity { get; set; } = 1;

    public UpdateQuantityRequest() { }

    public UpdateQuantityRequest(int quantity)
    {
        Quantity = quantity;
    }
}
