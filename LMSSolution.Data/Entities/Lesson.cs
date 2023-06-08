using LMSSolution.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public StudyShiff Shiff { get; set; }
        public LessonStatus Status { get; set; }

        public int CreditClassId { get; set; }
        public CreditClass CreditClass { get; set; }
    }
}
