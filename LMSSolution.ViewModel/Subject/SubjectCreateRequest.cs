using LMSSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Subject
{
    public class SubjectCreateRequest
    {
        public string Name { get; set; }
        public int NumberOfLesson { get; set; }
        public List<SubjectMajorViewModel>? SubjectMajors { get; set; }
    }

    public class SubjectMajorViewModel
    {
        public int MajorId { get; set; }
    }
}
