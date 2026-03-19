using System.Data;
using Bitstore.DTO.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace Bitstore.Validators;

public class LoginUserRequestValidator: AbstractValidator<LoginUserRequest>
{
    public LoginUserRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format")
            .Length(5,50).WithMessage("Invalid email length");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .Length(8,50).WithMessage("Invalid password length");
    }
}