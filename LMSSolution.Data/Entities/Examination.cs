using LMSSolution.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class Examination
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public StudyShiff Shiff { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int ExamineMethodId { get; set; }
        public ExamineMethod ExamineMethod { get; set; }
    }
}
