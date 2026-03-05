using Bitstore.Core.Models;

namespace Bitstore.Core.Abstractions;

public interface IUserRepository
{
    Task Create(User user);
    Task<List<User>> GetAll();
    Task<User> GetByEmail(string email);
    Task<User> GetById(Guid id);
}