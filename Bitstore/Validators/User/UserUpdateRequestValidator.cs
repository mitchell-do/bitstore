using Bitstore.Application.DTO.User;
using FluentValidation;

namespace Bitstore.Validators.User;

public class UserUpdateRequestValidator: AbstractValidator<UserUpdateRequest>
{
    public UserUpdateRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required")
            .Length(3,15).WithMessage("Username must be between 3 and 15 characters");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format")
            .Length(5,50).WithMessage("Invalid email length");
        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Role is required")
            .Length(1,20).WithMessage("Role must be between 1 and 20 characters");
    }
}