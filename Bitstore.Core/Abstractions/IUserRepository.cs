using Bitstore.Core.Models;

namespace Bitstore.Core.Abstractions;

public interface IUserRepository
{
    Task Create(User user);
    Task<List<User>> GetAll();
    Task<bool> ExistsByEmail(string email);
    Task<User> GetByEmail(string email);
    Task<User> GetById(Guid id);
    Task Update(User user);
    Task<bool> Delete(Guid userId);
    Task<decimal> GetBalance(Guid userId);
    Task UpdateBalance(Guid userId, decimal amount);
}