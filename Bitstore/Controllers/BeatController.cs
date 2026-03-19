using System.Security.Claims;
using Bitstore.Core.Abstractions;
using Bitstore.Core.Enums;
using Bitstore.Core.Models;
using Bitstore.DTO.Beat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;

namespace Bitstore.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BeatController(IBeatService beatService,
    IUserService userService): Controller
{
    private readonly IBeatService _beatService = beatService;
    private readonly IUserService _userService = userService;
    
    [HttpGet("allbeats")]
    public async Task<ActionResult<List<Beat>>> GetAllBeats()
    {
        var beats = await _beatService.GetBeats();
        var response = beats.Select(b => 
            new BeatResponse(b.Title, b.Price, b.AudioUrl,
                b.Description, b.CoverUrl)).ToList();
        return Ok(response);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<Beat>>> GetBeatsByUser(Guid userId)
    {
        var currentUserId = Guid.Parse(User
            .FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        if (currentUserId == Guid.Empty)
        {
            throw new UnauthorizedAccessException();
        }
        var beats = await _beatService.GetBeatsByUser(currentUserId);
        var response = beats.Select(b => 
            new BeatResponse(b.Title, b.Price, b.AudioUrl,
                b.Description, b.CoverUrl)).ToList();
        return Ok(response);
    }
    
    [HttpPost("addbeat")]
    public async Task CreateBeat([FromBody] BeatRequest request)
    {
        var currentUserId = Guid.Parse(User
            .FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        if (currentUserId == Guid.Empty)
            throw new UnauthorizedAccessException();
        
        await _beatService.CreateBeat(currentUserId, request);
    }
}