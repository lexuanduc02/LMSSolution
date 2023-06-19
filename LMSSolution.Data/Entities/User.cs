using LMSSolution.Data.Enum;
using Microsoft.AspNetCore.Identity;

namespace LMSSolution.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime Dob { get; set; }

        public int? ClassId { get; set; }
        public Class? Class { get; set; }

        public int? MajorId { get; set; }
        public Major? Major { get; set; }

        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
        public ICollection<Class> Classes { get; set; } = new List<Class>();
        public ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();
        public ICollection<StudentExamination> StudentExaminations { get; set; } = new List<StudentExamination>();
        public ICollection<TeacherExamination> TeacherExaminations { get; set; } = new List<TeacherExamination>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
