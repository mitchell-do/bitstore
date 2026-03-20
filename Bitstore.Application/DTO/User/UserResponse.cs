namespace Bitstore.Application.DTO.User;

public record UserResponse(
    Guid UserId,
    string Username,
    string Email,
    string Role,
    decimal Balance);