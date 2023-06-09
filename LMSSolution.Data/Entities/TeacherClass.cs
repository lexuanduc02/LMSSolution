using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class TeacherClass
    {
        public Guid TeacherId { get; set; }
        public User Teacher { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public string Description { get; set; }
    }
}
