using LMSSolution.ViewModels.System.UserBase;

namespace LMSSolution.ViewModels.System.Teacher
{
    public class TeacherCreateRequest : UserCreateRequest
    {
        public List<int>? ClassIds { get; set; }
    }
}
