using FluentValidation;

namespace LMSSolution.ViewModels.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() 
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Your email is invalid");

            RuleFor(p => p.Password).MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.");
        }
    }
}
