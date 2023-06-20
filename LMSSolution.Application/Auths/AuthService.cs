using LMSSolution.Data.Entities;
using LMSSolution.ViewModels.Auth;
using LMSSolution.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LMSSolution.Application.Auths
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public AuthService(UserManager<User> userManager, 
            SignInManager<User> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) 
                return new ApiErrorResult<string>("Email hoặc mật khẩu không chính xác");

            //var checkRole = await _userManager.IsInRoleAsync(user, "admin") || await _userManager.IsInRoleAsync(user, "officer");

            //if (!checkRole)
            //{
            //    return null;
            //}

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);

            if(!result.Succeeded)
            {
                return new ApiErrorResult<string>("Email hoặc mật khẩu không chính xác");
            }

            var roles = _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Role, string.Join(";", roles)),
            };

            var issuer = config["JwtSettings:Issuer"];
            var audience = config["JwtSettings:Audience"];
            var key = Encoding.UTF8.GetBytes(config["JwtSettings:Key"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDesciptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(8),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDesciptior);

            var jwtToken = tokenHandler.WriteToken(token);

            return new ApiSuccessResult<string>(jwtToken);
        }

        public Task<bool> RegisterRequest(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
