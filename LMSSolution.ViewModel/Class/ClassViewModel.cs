using LMSSolution.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Class
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserViewModel Teacher { get; set; }
    }
}
