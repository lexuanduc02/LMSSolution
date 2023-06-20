using FluentValidation.AspNetCore;
using LMSSolution.Application.Auths;
using LMSSolution.Application.Classes;
using LMSSolution.Application.Courses;
using LMSSolution.Application.Majors;
using LMSSolution.Data.EF;
using LMSSolution.Data.Entities;
using LMSSolution.Utilities.Constants;
using LMSSolution.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    //Connect to Database
builder.Services.AddDbContext<LMSDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddControllers(options =>
//{
//    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
//});

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger eShop Solution", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

string issuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer");
string audience = builder.Configuration.GetValue<string>("JwtSettings:Audience");
string singingKey = builder.Configuration.GetValue<string>("JwtSettings:Key");
byte[] signingKeyBytes = Encoding.UTF8.GetBytes(singingKey);

builder.Services.AddAuthentication(opt =>
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

    //Add Identity
builder.Services.AddDefaultIdentity<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<LMSDbContext>()
    .AddDefaultTokenProviders();

//Declare DI
builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IClassService, ClassService>();
builder.Services.AddTransient<IMajorService, MajorService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
