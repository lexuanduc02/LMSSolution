using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Subject
{
    public class SubjectEditRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfLesson { get; set; }
    }
}
