using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;

namespace Bitstore.Application.Services;

public class UserService(IUserRepository userRepository): IUserService
{
    public async Task<User> GetUserById(Guid userId)
    {
        var user = await userRepository.GetById(userId);
        return user;
    }
}