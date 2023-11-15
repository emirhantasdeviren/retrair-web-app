namespace Inveon.eCommerceExample.Carts.API.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string? ImagePath { get; set; }
    public int Quantity { get; set; } = 1;

    public Product(string name) => Name = name;
}
