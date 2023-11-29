namespace Inveon.eCommerceExample.Carts.API.Models;

public class CartItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; } = 1;

    public virtual Cart? Cart { get; set; }

    public CartItem(Guid cartId, Guid productId)
    {
        CartId = cartId;
        ProductId = productId;
    }
}
