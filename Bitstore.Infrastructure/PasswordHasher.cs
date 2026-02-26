using Bitstore.Core.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Bitstore.Infrastructure;

public class PasswordHasher: IPasswordHasher
{
    public string Generate(string password) => 
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string paswword, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(paswword, hashedPassword);
}