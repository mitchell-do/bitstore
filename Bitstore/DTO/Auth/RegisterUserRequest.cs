using System.ComponentModel.DataAnnotations;

namespace Bitstore.DTO.Auth;

public record RegisterUserRequest(
    [Required] string Username,
    [Required] string Email,
    [Required] string Password);
