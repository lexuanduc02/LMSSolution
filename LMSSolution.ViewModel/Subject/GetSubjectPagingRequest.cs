using LMSSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Subject
{
    public class GetSubjectPagingRequest : PagingRequestBase
    {
        public string? KeyWord { get; set; }
    }
}
