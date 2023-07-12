
using LMSSolution.Utilities.Enums;

namespace LMSSolution.Data.Entities
{
    public class CreditClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CreditClassStatusEnum Status { get; set; }
        public TeachingAssignStatusEnum TeachingAssign { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
