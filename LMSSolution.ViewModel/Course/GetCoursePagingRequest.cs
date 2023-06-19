using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSSolution.ViewModels.Common;

namespace LMSSolution.ViewModels.Course
{
    public class GetCoursePagingRequest : PagingRequestBase
    {
        public string? KeyWord { get; set; }
    }
}
