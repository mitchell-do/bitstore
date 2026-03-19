using Bitstore.DTO.Auth;
using FluentValidation;

namespace Bitstore.Validators;

public class RegisterUserRequestValidator: AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required")
            .Length(3,15).WithMessage("Username must be between 3 and 15 characters");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .Length(8,50).WithMessage("Invalid password length");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format")
            .Length(5,50).WithMessage("Invalid email length");
    }
}