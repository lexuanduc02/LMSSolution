using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class StudyShiff
    {
        public int Id { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }
        public string Description { get; set; }

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<Examination> Examinations { get; set; } = new List<Examination>();
    }
}
