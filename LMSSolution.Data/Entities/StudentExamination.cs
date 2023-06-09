using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class StudentExamination
    {
        public Guid StudentId { get; set; }
        public User Student { get; set; }

        public int ExaminationId { get; set; }
        public Examination Examination { get; set; }

        public string Description { get; set; }
    }
}
