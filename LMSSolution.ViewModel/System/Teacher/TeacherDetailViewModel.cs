using LMSSolution.ViewModels.System.User;
using LMSSolution.ViewModels.System.UserBase;

namespace LMSSolution.ViewModels.System.Teacher
{
    public class TeacherDetailViewModel : UserViewModel
    {
        public List<ClassDTO> Classes { get; set; }
    }

    public class ClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
