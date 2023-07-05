using LMSSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.System.UserBase
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string? KeyWord { get; set; }
    }
}
