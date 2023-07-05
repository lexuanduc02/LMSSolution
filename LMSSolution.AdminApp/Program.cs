using FluentValidation.AspNetCore;
using LMSSolution.ApiIntegration.Auth;
using LMSSolution.ApiIntegration.Course;
using LMSSolution.ApiIntegration.Major;
using LMSSolution.ApiIntegration.Subject;
using LMSSolution.ApiIntegration.System.Teacher;
using LMSSolution.Application.Subjects;
using LMSSolution.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv =>
    {
        fv.AutomaticValidationEnabled = true;
        fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>();
    });

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddHttpClient();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Declare DI
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IAuthApiClient, AuthApiClient>();
builder.Services.AddTransient<ICourseApiClient, CourseApiClient>();
builder.Services.AddTransient<ISubjectApiClient, SubjectApiClient>();
builder.Services.AddTransient<IMajorApiClient, MajorApiClient>();
builder.Services.AddTransient<ITeacherApiClient, TeacherApiClient>();

//Add Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login/";
        options.AccessDeniedPath = "/Auth/AccessDenied/";
    });

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
