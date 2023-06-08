using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfLesson  { get; set; }

        public ICollection<CreditClass> CreditClasses { get; set; } = new List<CreditClass>();
        public ICollection<SubjectMajor> SubjectMajors { get; set; } = new List<SubjectMajor>();
        public ICollection<Examination> Examinations { get; set; } = new List<Examination>();
    }
}
