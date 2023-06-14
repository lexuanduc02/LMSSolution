using LMSSolution.ViewModels.Auth;
using LMSSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ApiIntegration.Auth
{
    public interface IAuthApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
    }
}
