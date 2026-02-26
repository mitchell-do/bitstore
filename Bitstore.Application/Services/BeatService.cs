using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;

namespace Bitstore.Application.Services;

public class BeatService(IBeatRepository beatRepository) : IBeatService
{
    private readonly IBeatRepository _beatRepository = beatRepository;

    public async Task<List<Beat>> GetBeats()
    {
        var beats = await _beatRepository.GetAll();
        return beats;
    }

    public async Task CreateBeat(Beat beat)
    {   
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