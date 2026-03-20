using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;
using Bitstore.DTO.Beat;
using Serilog;

namespace Bitstore.Application.Services;

public class BeatService(
    IBeatRepository beatRepository,
    IUserRepository userRepository, 
    ICurrentUserService currentUserService) 
    : IBeatService
{
    private readonly IBeatRepository _beatRepository = beatRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<List<BeatResponse>> GetBeats()
    {
        Log.Information("Getting all beats");
        
        var beats = await _beatRepository.GetAll();
        
        var response = beats.Select(b => 
            new BeatResponse(b.Title, b.Price, b.AudioUrl,
                b.Description, b.CoverUrl)).ToList();
        
        Log.Information("Returned {Count} beats", response.Count);
        
        return response;
    }

    public async Task<List<BeatResponse>> GetBeatsByUser(Guid userId)
    {
        var currentUserId = _currentUserService.GetUserId();
        var currentUserRole = _currentUserService.GetUserRole();
        
        if (currentUserRole != "Admin" && currentUserId != userId)
        {
            Log.Warning("User {CurrentUserId} attempted to access beats of user {TargetUserId}", 
                currentUserId, userId);
            throw new UnauthorizedAccessException("You can only view your own beats");
        }
        
        Log.Information("Getting beats for user {UserId}", userId);
        
        var beats = await _beatRepository.GetByUserId(userId);
        
        var response = beats.Select(b => 
            new BeatResponse(b.Title, b.Price, b.AudioUrl,
                b.Description, b.CoverUrl)).ToList();
        
        Log.Information("Returned {Count} beats", response.Count);
        
        return response;
    }

    public async Task CreateBeat(BeatRequest request)
    {   
        var currentUserId = _currentUserService.GetUserId();
        
        Log.Information("User {UserId} is creating a new beat", currentUserId);
        
        var user = await _userRepository.GetById(currentUserId);

        var beat = Beat.Create(
            request.Title,
            request.Price,
            request.AudioUrl,
            true,
            request.Description,
            request.CoverUrl,
            user);
        
        await _beatRepository.Create(beat);
        
        Log.Information("Created new beat {BeatId} by {UserId}", beat.Id, user.Id);
    }

    public Task UpdateBeat()
    {
        throw new Exception();
    }

    public Task DeleteBeat()
    {
        throw new Exception();
    }
}