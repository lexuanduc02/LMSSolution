using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class SubjectMajor
    {
        public int MajorId { get; set; }
        public Major Major { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
