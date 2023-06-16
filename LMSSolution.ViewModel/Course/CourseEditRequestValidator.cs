using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Course
{
    public class CourseEditRequestValidator : AbstractValidator<CourseEditRequest>
    {
        public CourseEditRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên khóa không được để trống.");

            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Ngày bắt đầu không được để trống.")
                .GreaterThan(x => x.EndDate).WithMessage("Ngày bắt đầu cần trước ngày kết thúc.");

            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Ngày kết thúc không được để trống.");
        }
    }
}
