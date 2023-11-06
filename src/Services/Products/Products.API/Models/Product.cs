namespace Inveon.eCommerceExample.Products.API.Models;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string? ImagePath { get; set; }
}
