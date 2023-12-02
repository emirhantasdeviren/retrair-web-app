using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Inveon.eCommerceExample.Payment.API.Models;

public class Item
{
    public Guid Id { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public ItemType ItemType { get; set; }
    public required string Name { get; set; }
    public string Category { get; set; } = "Sneaker";
    public double Price { get; set; }
}
