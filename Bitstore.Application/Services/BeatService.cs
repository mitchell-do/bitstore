using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;
using Bitstore.DTO.Beat;

namespace Bitstore.Application.Services;

public class BeatService(IBeatRepository beatRepository,
    IUserRepository userRepository) : IBeatService
{
    private readonly IBeatRepository _beatRepository = beatRepository;
    private readonly IUserRepository _userRepository = userRepository;
    
    public async Task<List<Beat>> GetBeats()
    {
        var beats = await _beatRepository.GetAll();
        return beats;
    }

    public async Task<List<Beat>> GetBeatsByUser(Guid userId)
    {
        var user = await _userRepository.GetById(userId);
        if (user == null)
        {
            throw new Exception();
        }
        var beats = user.Beats.ToList();
        return beats;
    }

    public async Task CreateBeat(Guid userId, BeatRequest request)
    {   
        var user = await _userRepository.GetById(userId);
        if (user == null)
            throw new Exception("User not found");

        var beat = Beat.Create(
            request.Title,
            request.Price,
            request.AudioUrl,
            false,
            request.Description,
            request.CoverUrl,
            user);
        
        user.AddBeat(beat);
        await _beatRepository.Create(beat);
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