using Bitstore.Core.Abstractions;
using Bitstore.DTO.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bitstore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService): Controller
{
    private readonly IUserService _userService =  userService;
    
    [Authorize(Roles = "Admin")]
    [HttpGet("balance")]
    public async Task<ActionResult<decimal>> GetBalanceOfUser(Guid userId)
    {
        var balance = await _userService.GetBalance(userId);
        return Ok(balance);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatebalance")]
    public async Task<IActionResult> UpdateBalance(Guid userId, decimal amount)
    {
        await _userService.UpdateBalance(userId, amount);
        return Ok();
    }
    
}