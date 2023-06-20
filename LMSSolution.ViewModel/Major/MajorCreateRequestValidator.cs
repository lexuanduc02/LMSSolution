using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Major
{
    public class MajorCreateRequestValidator : AbstractValidator<MajorCreateRequest>
    {
        public MajorCreateRequestValidator() 
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Tên không được để trống")
                .NotNull().WithMessage("Tên không được để trống")
                .MaximumLength(30).WithMessage("Tên không quá 30 kí tự");

            RuleFor(m => m.Description).NotEmpty().WithMessage("Mô tả không được để trống")
                        .NotNull().WithMessage("Mô tả không được để trống")
                        .MaximumLength(200).WithMessage("Mô tả không quá 200 kí tự");
        }
    }
}
