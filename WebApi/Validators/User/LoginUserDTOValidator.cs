using Application.Common.DTOs.User;
using FluentValidation;

namespace WebApi.Validators.User
{
    public class LoginUserDTOValidator: AbstractValidator<LoginUserRequestDTOs>
    {
        public LoginUserDTOValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
