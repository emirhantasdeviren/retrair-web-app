using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Inveon.eCommerceExample.Auth.API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Inveon.eCommerceExample.Auth.API.Service;

public class JwtGenerator : ITokenGenerator
{
    private readonly JwtOptions _jwtOpts;

    public JwtGenerator(IOptions<JwtOptions> jwtOpts)
    {
        _jwtOpts = jwtOpts.Value;
    }

    public string GenerateToken(ApplicationUser applicationUser)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_jwtOpts.Secret);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),
            new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
            new Claim(JwtRegisteredClaimNames.Name, applicationUser.Name),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _jwtOpts.Audience,
            Issuer = _jwtOpts.Issuer,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
