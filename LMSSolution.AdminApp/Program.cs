using FluentValidation;
using LMSSolution.AdminApp.ModuleRegistrations;
using LMSSolution.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                        .Build();

var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

services.AddRazorPages()
    .AddRazorRuntimeCompilation();

services.AddHttpClient();
services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

//Declare DI
services.AddServiceCollection();

//Add Authentication
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login/";
        options.AccessDeniedPath = "/Auth/AccessDenied/";
    });

services.AddAutoMapper(typeof(Program).Assembly);

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
