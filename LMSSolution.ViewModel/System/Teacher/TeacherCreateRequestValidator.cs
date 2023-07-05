using FluentValidation;
using LMSSolution.ViewModels.System.UserBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.System.Teacher
{
    public class TeacherCreateRequestValidator : AbstractValidator<TeacherCreateRequest>
    {
        public TeacherCreateRequestValidator() 
        {
            Include(new UserCreateRequestValidator());
        }
    }
}
