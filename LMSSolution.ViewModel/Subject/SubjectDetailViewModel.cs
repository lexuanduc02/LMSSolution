using Bogus.Bson;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Subject
{
    public class SubjectDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfLesson { get; set; }
        public List<SubjectMajorDto> SubjectMajors { get; set; }
        public List<TeacherSubjectDto> TeacherSubjects { get; set; }
    }

    public class SubjectMajorDto
    {
        public int MajorId { get; set; }
        public MajorDto MajorInfor { get; set; }
    }

    public class MajorDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TeacherSubjectDto
    {
        public Guid TeacherId { get; set; }
        public TeacherDto TeacherInfor { get; set; }
    }

    public class TeacherDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
