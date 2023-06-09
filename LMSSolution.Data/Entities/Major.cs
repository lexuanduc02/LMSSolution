using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Entities
{
    public class Major
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }

        public ICollection<Class> Classes { get; set; }
        public ICollection<SubjectMajor> SubjectMajors { get; set; } = new List<SubjectMajor>();
        public ICollection<User> Students { get; set; } = new List<User>();
    }
}
