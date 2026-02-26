using Bitstore.Core.Abstractions;
using Bitstore.DTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Bitstore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IAuthService authService): Controller
{
    private readonly IAuthService _authService = authService;
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginUserRequest request)
    {
       var token =  await _authService.Login(request.Email, request.Password);
       return Ok(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        await _authService.Resgister(request.Username,request.Email, request.Password);
        return Ok();
    }
}