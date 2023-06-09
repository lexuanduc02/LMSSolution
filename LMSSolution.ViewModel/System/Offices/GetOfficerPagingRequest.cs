using LMSSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.System.Offices
{
    public class GetOfficerPagingRequest : PagingRequestBase
    {
        public string? KeyWord { get; set; }
    }
}
