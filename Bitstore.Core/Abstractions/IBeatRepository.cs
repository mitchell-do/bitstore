using Bitstore.Core.Models;

namespace Bitstore.Core.Abstractions;

public interface IBeatRepository
{
    Task<List<Beat>> GetAll();
    Task Create(Beat beat);
    Task Delete();
    Task Update();
    Task<List<Beat>> GetByUserId(Guid userId);
}