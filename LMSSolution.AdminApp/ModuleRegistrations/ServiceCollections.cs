using LMSSolution.ApiIntegration.Auth;
using LMSSolution.ApiIntegration.Course;
using LMSSolution.ApiIntegration.Major;
using LMSSolution.ApiIntegration.Subject;
using LMSSolution.ApiIntegration.System.Teacher;

namespace LMSSolution.AdminApp.ModuleRegistrations
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddServiceCollection (this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>()
                    .AddTransient<IAuthApiClient, AuthApiClient>()
                    .AddTransient<ICourseApiClient, CourseApiClient>()
                    .AddTransient<ISubjectApiClient, SubjectApiClient>()
                    .AddTransient<IMajorApiClient, MajorApiClient>()
                    .AddTransient<ITeacherApiClient, TeacherApiClient>()
                ;

            return services;
        }
    }
}
