using Bitstore.Application.DTO.User;
using FluentValidation;

namespace Bitstore.Validators.User;

public class UserUpdateBalanceRequestValidator: AbstractValidator<UserUpdateBalanceRequest>
{
    public UserUpdateBalanceRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required");
        RuleFor(x => x.Amount)
            .NotNull().WithMessage("Amount is required")
            .GreaterThanOrEqualTo(0).WithMessage("Amount must be greater than 0");
    }
}