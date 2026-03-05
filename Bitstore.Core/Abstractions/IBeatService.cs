using Bitstore.Core.Models;

namespace Bitstore.Core.Abstractions;

public interface IBeatService
{
    Task<List<Beat>> GetBeats();
    Task<List<Beat>> GetBeatByUser(Guid userId);
    Task CreateBeat(Beat beat);
    Task UpdateBeat();
    Task DeleteBeat();
}