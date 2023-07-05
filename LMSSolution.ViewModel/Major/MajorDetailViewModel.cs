using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Major
{
    public class MajorDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ClassViewModel> Classes { get; set; }
        public List<SubjectMajorViewModel> SubjectMajors { get; set; }
    }

    public class ClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseViewModel Course { get; set; }
        public TeacherViewModel Teacher { get; set; }
    }

    public class TeacherViewModel
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
        public Guid Id { get; set; }
    }

    public class SubjectMajorViewModel
    {
        public int SubjectId { get; set; }
        public SubjectViewModel Subject { get; set; }
    }

    public class SubjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfLesson { get; set; }
    }

    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
