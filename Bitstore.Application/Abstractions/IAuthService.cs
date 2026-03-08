namespace Bitstore.Core.Abstractions;

public interface IAuthService
{
    Task Resgister(string username, string email, string password);
    Task<string> Login(string email, string password);
}