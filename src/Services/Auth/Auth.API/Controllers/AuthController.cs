using Inveon.eCommerceExample.Auth.API.Infrastructure;
using Inveon.eCommerceExample.Auth.API.Models;
using Inveon.eCommerceExample.Auth.API.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inveon.eCommerceExample.Auth.API.Controllers;

[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthContext _authCtx;
    private readonly UserManager<ApplicationUser> _userMgr;
    private readonly RoleManager<IdentityRole> _roleMgr;
    private readonly ITokenGenerator _tokenGenerator;

    public AuthController(AuthContext authCtx, UserManager<ApplicationUser> userMgr, RoleManager<IdentityRole> roleMgr, ITokenGenerator tokenGenerator)
    {
        _authCtx = authCtx;
        _userMgr = userMgr;
        _roleMgr = roleMgr;
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserResponse>> Register([FromBody] RegistrationRequest registrationRequest)
    {
        var user = new ApplicationUser
        {
            UserName = registrationRequest.Email,
            Email = registrationRequest.Email,
            NormalizedEmail = registrationRequest.Email.ToUpper(),
            Name = registrationRequest.Name,
            PhoneNumber = registrationRequest.PhoneNumber,
        };

        try
        {
            var result = await _userMgr.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                var userToReturn = _authCtx.ApplicationUsers.Single(u => u.UserName == registrationRequest.Email);

                var userRes = new UserResponse
                {
                    Email = userToReturn.Email,
                    Id = userToReturn.Id,
                    Name = userToReturn.Name,
                    PhoneNumber = userToReturn.PhoneNumber,
                };

                return Ok(userRes);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception _e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginReq)
    {
        var user = _authCtx.ApplicationUsers.SingleOrDefault(u => u.UserName == loginReq.UserName);
        if (user == null)
        {
            return NotFound();
        }

        bool isValid = await _userMgr.CheckPasswordAsync(user, loginReq.Password);
        if (!isValid)
        {
            return Unauthorized();
        }

        var userRes = new UserResponse
        {
            Email = user.Email,
            Id = user.Id,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber,
        };
        var res = new LoginResponse
        {
            User = userRes,
            Token = _tokenGenerator.GenerateToken(user),
        };

        return Ok(res);
    }
}
