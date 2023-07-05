using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Major;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ApiIntegration.Major
{
    public interface IMajorApiClient
    {
        Task<List<MajorViewModel>> GetAllMajor();
    }
}
