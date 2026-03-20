namespace Bitstore.Application.DTO.User;

public record UserUpdateRequest(
    string Username,
    string Email,
    string Role);