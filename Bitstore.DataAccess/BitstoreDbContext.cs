using Bitstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bitstore.DataAccess;

public class BitstoreDbContext: DbContext
{
    public BitstoreDbContext(DbContextOptions<BitstoreDbContext> options)
    : base(options)
    {
        
    }
    //public DbSet<UserEntity> Users { get; set; }
    public DbSet<BeatEntity> Beats { get; set; }
    
}