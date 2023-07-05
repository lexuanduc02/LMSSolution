using LMSSolution.ViewModels.Auth;
using LMSSolution.ViewModels.Common;

namespace LMSSolution.Application.Auths
{
    public interface IAuthService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<bool> RegisterRequest(RegisterRequest request);
    }
}
