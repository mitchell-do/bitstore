using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;
using Serilog;

namespace Bitstore.Application.Services;

public class UserService(IUserRepository userRepository,
    ICurrentUserService currentUserService): IUserService
{
    public async Task<User> GetUserById(Guid userId)
    {
        var user = await userRepository.GetById(userId);
        return user;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await userRepository.GetAll();
        return users;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await userRepository.GetByEmail(email);
        return user;
    }

    public async Task<bool> DeleteUserById(Guid userId)
    {
        var result = await userRepository.Delete(userId);
        
        return result;
    }

    public async Task<Guid> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateUser(User user)
    {
        await userRepository.Create(user);
        return user.Id;
    }

    public async Task<decimal> GetBalance(Guid userId)
    {
        var currentUserId = currentUserService.GetUserId();
        var isAdmin = currentUserService.IsInRole("Admin");
        if (currentUserId != userId && !isAdmin)
        {
            Log.Warning("User {CurrentUserId} attempted to view balance of user {TargetUserId}"
            ,currentUserId, userId);
            throw new UnauthorizedAccessException("You can only view your own balance");
        }
                
        Log.Information("Balance requested for user {UserId}", userId);
        
        var balance = await userRepository.GetBalance(userId);
        return balance;
    }

    public async Task UpdateBalance(Guid userId, decimal amount)
    {
        var currentUserId = currentUserService.GetUserId();
        var isAdmin = currentUserService.IsInRole("Admin");
        if (currentUserId != userId && !isAdmin)
        {
            Log.Warning("User {CurrentUserId} attempted to update balance of user {TargetUserId}"
                ,currentUserId, userId);
            throw new UnauthorizedAccessException("Only admin users can update balance");
        }
        Log.Information("Balance of user {userId} was updated", userId);
        
        await userRepository.UpdateBalance(userId, amount);
        
    }
}