namespace Bitstore.Core.Abstractions;

public interface IPasswordHasher
{
    string Generate(string password);
    bool Verify(string paswword, string hashedPassword);
}