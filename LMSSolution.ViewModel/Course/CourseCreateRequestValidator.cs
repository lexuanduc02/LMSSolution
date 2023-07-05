﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Course
{
    public class CourseCreateRequestValidator : AbstractValidator<CourseCreateRequest>
    {
        public CourseCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên khóa không được để trống.");

            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Ngày bắt đầu không được để trống.");

            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Ngày kết thúc không được để trống.");
        }
    }
}
