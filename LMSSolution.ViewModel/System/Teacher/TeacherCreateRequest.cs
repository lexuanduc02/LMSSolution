using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.System.UserBase;

namespace LMSSolution.ViewModels.System.Teacher
{
    public class TeacherCreateRequest : UserCreateRequest
    {
        public List<int>? ClassIds { get; set; }
        public List<int>? SubjectIds { get; set; }
    }
}
