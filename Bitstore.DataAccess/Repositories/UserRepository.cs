using Bitstore.Application.Exceptions;
using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;
using Bitstore.DataAccess.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Bitstore.DataAccess.Repositories;

public class UserRepository(BitstoreDbContext context): IUserRepository
{
    private readonly BitstoreDbContext _context = context;
    
    public async Task<Guid> Create(User user)
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

        return user.Id;
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

    public async Task Update(User user)
    {
        await _context.Users
            .Where(u => u.Id == user.Id)
            .ExecuteUpdateAsync<UserEntity>(u => u
                .SetProperty(u => u.Username, user.Username)
                .SetProperty(u => u.PasswordHash, user.PasswordHash)
                .SetProperty(u => u.Email, user.Email)
                .SetProperty(u => u.Role, user.Role)
                .SetProperty(u => u.Balance, user.Balance));
        
    }

    public async Task<bool> Delete(Guid userId)
    {
       var result = await _context.Users
            .Where(u => u.Id == userId)
            .ExecuteDeleteAsync();
       if (result == 0)
            throw new NullReferenceException($"User with id {userId} not found");
        
       return true;
    }

    public async Task<decimal> GetBalance(Guid userId)
    {
        var userEntity = await _context.Users
            .Where(u => u.Id == userId)
            .Select(u => new {u.Balance})
            .FirstOrDefaultAsync();
        
        if (userEntity == null)
            throw new NotFoundException($"User with id {userId} not found");
        return userEntity.Balance;
    }

    public async Task UpdateBalance(Guid userId, decimal amount)
    {
        var updatedCount = await _context.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(u => u.Balance, amount));
        
        if (updatedCount == 0)
            throw new NotFoundException($"User with id {userId} not found");
    }
}