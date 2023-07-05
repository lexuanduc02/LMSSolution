using FluentValidation;

namespace LMSSolution.ViewModels.System.UserBase
{
    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username không được để trống.")
                .MaximumLength(15).WithMessage("Username không quá 15 kí tự.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu không được để trống.");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Tên không được để trống.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Tên không được để trống.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Email không hợp lệ")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email không hợp lệ");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Số điện thoại không được để trống.")
                .Matches(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").WithMessage("Số điện thoại không hợp lệ");

            RuleFor(x => x.Dob).NotEmpty().WithMessage("Ngày sinh không được để trống.")
                .Must(BeAValidAge).WithMessage("Ngày sinh không hợp lệ.");
        }

        private bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }
    }
}
