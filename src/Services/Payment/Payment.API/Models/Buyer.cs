namespace Inveon.eCommerceExample.Payment.API.Models;

public class Buyer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string IdentityNumber { get; set; }
    public required string Email { get; set; }
    public required string RegistrationAddress { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public string Ip { get; set; } = "0.0.0.0";
}
