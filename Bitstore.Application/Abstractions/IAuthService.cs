using Bitstore.DTO.Auth;

namespace Bitstore.Core.Abstractions;

public interface IAuthService
{
    Task Resgister(RegisterUserRequest request);
    Task<string> Login(LoginUserRequest request);
}