using Bitstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bitstore.DataAccess;

public class BitstoreDbContext(DbContextOptions<BitstoreDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<BeatEntity> Beats { get; set; }
    
}