using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int MajorId { get; set; }
        public Major Major { get; set; }

        public Guid TeacherId { get; set; }
        public User Teacher { get; set; }

        public ICollection<User> Students { get; set; } = new List<User>();
    }
}
