namespace Inveon.eCommerceExample.Auth.API.Models;

public class LoginResponse
{
    public UserResponse User { get; set; }
    public string Token { get; set; }
}
