using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RB.Core.Application.Interface;
using RB.Infrastructure.Repository;
using RB.Infrastructure.Repository.Services.User;
using RB.Infrastructure.Repository.Services.User.Interface;
using RB.Infrastructure.Repository.User;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
builder.Services.AddDbContext<UserDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ISignupValidations, SignupImplementation>();
builder.Services.AddScoped<ISignupFunctions, SignupFunctions>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
