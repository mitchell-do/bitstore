using Bitstore.Core.Models;

namespace Bitstore.Core.Abstractions;

public interface IUserService
{
    Task<User> GetUserById(Guid userId);
    Task<List<User>> GetAllUsers();
    Task<User> GetUserByEmail(string email);
    Task<bool> DeleteUserById(Guid userId);
    Task<Guid> UpdateUser(User user);
    Task<Guid> CreateUser(User user);
    Task<decimal> GetBalance(Guid userId);
    Task UpdateBalance(Guid userId, decimal amount);
}