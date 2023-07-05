using LMSSolution.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class StudentAttendance
    {
        public Guid StudentId { get; set; }
        public User Student { get; set; }

        public int AttendaceId { get; set; }
        public Attendance Attendance { get; set; }

        public string Description { get; set; }
        public AttendanceStatusEnum Status { get; set; }
    }
}
