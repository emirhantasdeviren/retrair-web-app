namespace Inveon.eCommerceExample.Carts.API.Models;

public class Cart
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Guid CustomerId { get; set; }

    public virtual List<CartItem> Items { get; set; } = new List<CartItem>();

    public Cart(Guid customerId)
    {
        CustomerId = customerId;
    }
}
