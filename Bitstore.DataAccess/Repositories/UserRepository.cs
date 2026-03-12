using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;
using Bitstore.DataAccess.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Bitstore.DataAccess.Repositories;

public class UserRepository(BitstoreDbContext context): IUserRepository
{
    private readonly BitstoreDbContext _context = context;
    
    public async Task Create(User user)
    {
        var userEntity = new UserEntity()
        {
            Id = user.Id,
            Username = user.Username,
            PasswordHash =  user.PasswordHash,
            Email = user.Email,
            Role = user.Role
        };
        await  _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAll()
    {
        var userEntities = await _context.Users
            .AsNoTracking()
            .ToListAsync();
        var users = userEntities
            .Select(u => User.Create(u.Username,
                 u.Email, u.PasswordHash, u.Role))
            .ToList();
        return users;
    }

    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email);
        if (userEntity == null)
        {
            throw new Exception("User not found");
        }
        var user = User.Create(userEntity.Username,userEntity.Email,
            userEntity.PasswordHash,  userEntity.Role);
        
        return user;
    }

    public async Task<User> GetById(Guid id)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .Include(u => u.Beats)
            .FirstOrDefaultAsync(u => u.Id == id);
        if (userEntity == null)
        {
            throw new Exception("User not found");
        }
        var user = User.Create(userEntity.Username,userEntity.Email, userEntity.PasswordHash, userEntity.Role);
        foreach (var beatEntity in userEntity.Beats)
        {
            var beat = Beat.Create(
                beatEntity.Title,
                beatEntity.Price,
                beatEntity.AudioUrl,
                beatEntity.IsPublished,
                beatEntity.Description,
                beatEntity.CoverUrl,
                user);
            
            user.AddBeat(beat);
        }
        
        return user;
    }
}