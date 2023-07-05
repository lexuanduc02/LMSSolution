using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class TeacherSubject
    {
        public Guid TeacherId { get; set; }
        public User Teacher { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
