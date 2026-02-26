using Bitstore.Core.Abstractions;
using Bitstore.Core.Models;

namespace Bitstore.Application.Services;

public class AuthService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider)
    : IAuthService
{
    public async Task Resgister(string username, string email,
        string password)
    {
        var hashedPassword = passwordHasher.Generate(password);
        var user = User.Create(Guid.NewGuid(), username, email, hashedPassword);
        await userRepository.Create(user);
    }

    public async Task<string> Login(string email, string password)
    {
        var user = await userRepository.GetByEmail(email);
        var result = passwordHasher.Verify(password, user.PasswordHash);
        if (result == false)
        {
            throw new Exception("Invalid username or password");
        }

        var token = jwtProvider.GenerateToken(user);
        return token;

    }
}

