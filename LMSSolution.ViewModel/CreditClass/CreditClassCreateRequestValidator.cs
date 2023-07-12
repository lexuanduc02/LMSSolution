using FluentValidation;

namespace LMSSolution.ViewModels.CreditClass
{
    public class CreditClassCreateRequestValidator : AbstractValidator<CreditClassCreateRequest>
    {
        public CreditClassCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên lớp không được để trống.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Trạng thái lớp không được để trống.");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Ngày bắt đầu không được để trống.");
            RuleFor(x => x.SubjectId).NotEmpty().WithMessage("Môn học không được để trống.");
        }
    }
}
