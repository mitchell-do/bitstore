using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;
using Bitstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bitstore.DataAccess.Repositories;

public class BeatRepository(BitstoreDbContext context): IBeatRepository
{
    private readonly BitstoreDbContext _context = context;
    
    public async Task<List<Beat>> GetAll()
    {
        
        var beatEntities = await _context.Beats
            .AsNoTracking()
            .ToListAsync();
        var beats = beatEntities
            .Select(b => Beat.Create(b.Id, b.Title, b.Price, b.AudioUrl, b.IsPublished))
            .ToList();
        return beats;
    }

    public async Task Create(Beat beat)
    {
        var beatEntity = new BeatEntity()
        {
            Id = beat.Id,
            Title = beat.Title,
            Price = beat.Price,
            AudioUrl = beat.AudioUrl,
            IsPublished = beat.IsPublished,
            CreatedAt = beat.CreatedAt
        };
        await _context.Beats.AddAsync(beatEntity);
        await _context.SaveChangesAsync();
    }

    public Task Delete()
    {
        throw new Exception();
    }

    public Task Update()
    {
        throw new Exception();
    }
}