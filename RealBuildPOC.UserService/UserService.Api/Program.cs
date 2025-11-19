using System.Data;
using Microsoft.Data.SqlClient;
using UserService.Application.Interfaces;
using UserService.Application.Services;
using UserService.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dapper DB Connection (Scoped per request)
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connection = new SqlConnection(builder.Configuration.GetConnectionString("UserDB"));
    // Optionally, open connection immediately
    // connection.Open();
    return connection;
});

// Application services
builder.Services.AddScoped<IUserService, UserService>();

// Infrastructure (Repository / DI)
builder.Services.AddInfrastructure();

var app = builder.Build();

// Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
