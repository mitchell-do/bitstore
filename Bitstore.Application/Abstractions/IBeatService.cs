using Bitstore.Core.Models;
using Bitstore.DTO.Beat;

namespace Bitstore.Core.Abstractions;

public interface IBeatService
{
    Task<List<Beat>> GetBeats();
    Task<List<Beat>> GetBeatsByUser(Guid userId);
    Task CreateBeat(Guid userId, BeatRequest request);
    Task UpdateBeat();
    Task DeleteBeat();
}