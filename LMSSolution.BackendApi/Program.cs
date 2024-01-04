using FluentValidation;
using LMSSolution.BackendApi.ModuleRegistrations;
using LMSSolution.Data.EF;
using LMSSolution.Data.Entities;
using LMSSolution.Utilities.Constants;
using LMSSolution.ViewModels.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                        .Build();

var services = builder.Services;

// Add services to the container.

//Connect to Database
services.AddDbContext<LMSDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString(SystemConstants.MainConnectionString)));

services.AddControllers()
        .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

services.AddSwagger();

services.AddAutoMapper(typeof(Program).Assembly);

services.AddAuthorizationCollection(configuration);

//Add Identity
services.AddDefaultIdentity<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<LMSDbContext>()
    .AddDefaultTokenProviders();

//Enable CORS
services.AddCORSCollection();

//Declare DI
services.AddServiceCollection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "LMSSolution API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(CORSConstants.Default);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
