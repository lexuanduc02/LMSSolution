using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Subject
{
    public class SubjectCreateRequestValidator : AbstractValidator<SubjectCreateRequest>
    {
        public SubjectCreateRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên môn không được để trống");
            RuleFor(x => x.NumberOfLesson).NotEmpty().WithMessage("Số tiết không được để trống");
        }
    }
}
