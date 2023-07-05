using FluentValidation;

namespace LMSSolution.ViewModels.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được để trống.")
                .NotNull().WithMessage("Email không được để trống.")
                .EmailAddress().WithMessage("Email không hợp lệ.");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Mật khẩu không được để trống.")
                .NotNull().WithMessage("Email không được để trống.")
                .MinimumLength(8).WithMessage("Mật khẩu phải có ít nhất 8 kí tự.")
                .MaximumLength(16).WithMessage("Mật khẩu không quá 16 kí tự.");
        }
    }
}
