using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;
using Bitstore.DTO.Beat;
using Microsoft.AspNetCore.Mvc;

namespace Bitstore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeatController(IBeatService beatService): Controller
{
    private readonly IBeatService _beatService = beatService;
    
    [HttpGet("allbeats")]
    public async Task<ActionResult<List<Beat>>> GetAllBeats()
    {
        var beats = await _beatService.GetBeats();
        var response = beats.Select(b => new BeatResponse(b.Title, b.Price, b.AudioUrl));
        return Ok(response);
    }

    [HttpPost("addbeat")]
    public async Task CreateBeat([FromBody] BeatRequest request)
    {
        var beat = Beat.Create(new Guid(), request.Title, request.Price, request.AudioUrl, true);
        await _beatService.CreateBeat(beat);
    }
}