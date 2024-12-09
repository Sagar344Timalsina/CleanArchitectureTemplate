using Application.Common.DTOs.User;
using FluentValidation;

namespace WebApi.Validators.User
{
    public class RegisterUserRequestDtoValidator : AbstractValidator<RegisterUserRequestDTOs>
    {
        public RegisterUserRequestDtoValidator()
        {
            RuleFor(x => x.UserName)
           .NotEmpty().WithMessage("Last name is required.")
           .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
