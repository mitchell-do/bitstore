using Bitstore.Core.Models;

namespace Bitstore.Core.Abstractions;

public interface IJwtProvider
{
    string GenerateToken(User user);
}