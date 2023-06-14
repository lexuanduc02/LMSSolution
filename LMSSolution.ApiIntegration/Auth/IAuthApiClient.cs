using LMSSolution.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ApiIntegration.Auth
{
    public interface IAuthApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
