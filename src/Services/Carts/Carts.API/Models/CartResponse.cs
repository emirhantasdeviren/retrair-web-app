namespace Inveon.eCommerceExample.Carts.API.Models;

public class CartResponse
{
    public Guid Id { get; set; }
    public List<Product> Items { get; set; } = new List<Product>();
}
