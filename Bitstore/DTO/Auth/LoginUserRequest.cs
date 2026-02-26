using System.ComponentModel.DataAnnotations;

namespace Bitstore.DTO.Auth;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);
