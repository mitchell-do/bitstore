using Bitstore.Core.Abstractions;
using Bitstore.Core.Enums;
using Bitstore.Core.Models;
using Bitstore.DTO.Auth;

namespace Bitstore.Application.Services;

public class AuthService(
    IUserService userService,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider)
    : IAuthService
{
    public async Task Resgister(RegisterUserRequest request)
    {
        var existingUser = await userService.GetUserByEmail(request.Email);
        if (existingUser != null)
            throw new Exception("User already exists");
        
        var hashedPassword = passwordHasher.Generate(request.Password);
        var user = User.Create(request.Username, request.Email,
            hashedPassword, "Customer");
        
        await userService.CreateUser(user);
    }

    public async Task<string> Login(LoginUserRequest request)
    {
        var user = await userService.GetUserByEmail(request.Email);
        var result = passwordHasher.Verify(request.Password, user.PasswordHash);
        
        if (result == false)
            throw new Exception("Invalid username or password");

        var token = jwtProvider.GenerateToken(user);
        return token;

    }
}

