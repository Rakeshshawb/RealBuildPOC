using System.Data;
using Microsoft.Data.SqlClient;
using OrderService.Application.Interfaces;
using OrderService.Application.Services;
using OrderService.Infrastructure.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IDbConnection>(_ => new SqlConnection(
builder.Configuration.GetConnectionString("UserDB")));


builder.Services.AddScoped<IOrderService, OrderService.Application.Services.OrderService>();
builder.Services.AddInfrastructure();


var app = builder.Build();


app.UseCors("AllowAll");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.Run();
