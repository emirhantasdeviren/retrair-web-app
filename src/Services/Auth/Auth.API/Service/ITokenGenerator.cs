using Inveon.eCommerceExample.Auth.API.Models;

namespace Inveon.eCommerceExample.Auth.API.Service;

public interface ITokenGenerator
{
    string GenerateToken(ApplicationUser applicationUser);
}
