using LMSSolution.ViewModels.Auth;

namespace LMSSolution.Application.Auth
{
    public interface IAuthService
    {
        Task<string> Authenticate(LoginRequest request);
        Task<bool> RegisterRequest(RegisterRequest request);
    }
}
