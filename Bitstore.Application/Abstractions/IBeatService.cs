using Bitstore.Core.Models;
using Bitstore.DTO.Beat;

namespace Bitstore.Core.Abstractions;

public interface IBeatService
{
    Task<List<BeatResponse>> GetBeats();
    Task<List<BeatResponse>> GetBeatsByUser(Guid userId);
    Task CreateBeat(BeatRequest request);
    Task UpdateBeat();
    Task DeleteBeat();
}