using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RB.Core.Application.DTO.Helpers;
using RB.Core.Application.Interface;
using RB.Infrastructure.Repository;
using RB.Infrastructure.Repository.Services.User;
using RB.Infrastructure.Repository.Services.User.Interface;
using RB.Infrastructure.Repository.User;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(GeneralProfile).Assembly);
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactJsDomain",
        policy => policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        );
});
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddMvc();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});

builder.Services.AddDbContext<UserDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ISignupValidations, SignupImplementation>();
builder.Services.AddScoped<ISignupFunctions, SignupFunctions>();
builder.Services.AddScoped<ISignupConfirmation, SignupConfirmationService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IVehicleRegistration, VehicleRegistration>();
builder.Services.AddScoped<IHostRideService, HostRideService>();
builder.Services.AddScoped<IJoinRideService, JoinRideService>();
builder.Services.AddScoped<IHostAcceptService, HostAcceptService>();


builder.Services.AddScoped(typeof(IGenericRepositoryOperation<>), typeof(GenericRepositoryOperations<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors("ReactJsDomain");
app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();
