using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyaiCoach.API.Middleware;
using MyaiCoach.Application;
using MyaiCoach.Domain.Entities;
using MyaiCoach.Domain.Role;
using MyaiCoach.Infrastructure;
using MyaiCoach.Persistance;
using MyaiCoach.Persistance.Contexts;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddPersistance();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddHttpContextAccessor();

builder.Services.AddIdentity<AppUser, AppRole>()
       .AddEntityFrameworkStores<ApiContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        RoleClaimType = ClaimTypes.Role,
        NameClaimType = ClaimTypes.Name,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my soo secret informaton for jwt This is my soo secret informaton for jwt"))
    };
});


var app = builder.Build();

// Middleware yapýlandýrmasý
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.UseMiddleware<WichAiServiceMiddleware>();

app.MapControllers();

app.Run();