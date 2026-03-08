using Bitstore.Core.Models;

namespace Bitstore.Core.Abstractions;

public interface IUserService
{
    Task<User> GetUserById(Guid userId);
}