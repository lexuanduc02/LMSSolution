using LMSSolution.Application.Auths;
using LMSSolution.Application.Classes;
using LMSSolution.Application.Courses;
using LMSSolution.Application.Majors;
using LMSSolution.Application.Subjects;
using LMSSolution.Application.Systems.Users.Teachers;
using LMSSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace LMSSolution.BackendApi.ModuleRegistrations
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddServiceCollection (this IServiceCollection services)
        {
            services.AddScoped<UserManager<User>, UserManager<User>>()
                    .AddScoped<SignInManager<User>, SignInManager<User>>()
                    .AddScoped<IAuthService, AuthService>()
                    .AddScoped<ICourseService, CourseService>()
                    .AddScoped<IClassService, ClassService>()
                    .AddScoped<IMajorService, MajorService>()
                    .AddScoped<ISubjectService, SubjectService>()
                    .AddScoped<ITeacherService, TeacherService>()
                ;

            return services;
        }
    }
}
