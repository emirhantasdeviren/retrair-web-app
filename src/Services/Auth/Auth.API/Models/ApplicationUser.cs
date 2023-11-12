using Microsoft.AspNetCore.Identity;

namespace Inveon.eCommerceExample.Auth.API.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}
