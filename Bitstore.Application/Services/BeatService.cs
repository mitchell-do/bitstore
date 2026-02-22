using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;

namespace Bitstore.Application.Services;

public class BeatService(IBeatRepository beatRepository) : IBeatService
{
    private readonly IBeatRepository _beatRepository = beatRepository;

    public Task<List<Beat>> GetBeats()
    {
        var beats = _beatRepository.GetAll();
        return beats;
    }

    public async Task CreateBeat(Beat beat)
    {   
        await  _beatRepository.Create(beat);
    }

    public Task UpdateBeat()
    {
        throw new NotImplementedException();
    }

    public Task DeleteBeat()
    {
        throw new NotImplementedException();
    }
}