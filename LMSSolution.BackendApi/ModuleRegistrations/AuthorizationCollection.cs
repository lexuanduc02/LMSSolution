using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LMSSolution.BackendApi.ModuleRegistrations
{
    public static class AuthorizationCollection
    {
        public static IServiceCollection AddAuthorizationCollection (this IServiceCollection services, IConfiguration configuration)
        {
            string issuer = configuration.GetValue<string>("JwtSettings:Issuer");
            string audience = configuration.GetValue<string>("JwtSettings:Audience");
            string singingKey = configuration.GetValue<string>("JwtSettings:Key");
            byte[] signingKeyBytes = Encoding.UTF8.GetBytes(singingKey);

            services.AddAuthentication(opt =>
                    {
                        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(opts =>
                    {
                        opts.RequireHttpsMetadata = false;
                        opts.SaveToken = true;
                        opts.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidIssuer = issuer,
                            ValidAudience = audience,
                            IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = false,
                            ValidateIssuerSigningKey = true,
                        };
                    });

            return services;
        }
    }
}
