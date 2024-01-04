using LMSSolution.Utilities.Constants;

namespace LMSSolution.BackendApi.ModuleRegistrations
{
    public static class CORSCollection
    {
        public static IServiceCollection AddCORSCollection (this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CORSConstants.Default,
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:7104")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}
