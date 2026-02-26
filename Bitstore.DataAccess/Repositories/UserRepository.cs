using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;
using Bitstore.DataAccess.Entities;
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
            .Select(u => User.Create(u.Id, u.Username,
                 u.Email, u.PasswordHash))
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
        var user = User.Create(userEntity.Id,userEntity.Username,userEntity.Email, userEntity.PasswordHash);
        return user;
    }
}