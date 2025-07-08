using EmployeeManagement.Data;
using EmployeeManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("EmployeeDb")
);
builder.Services.AddCors( options =>
{
    options.AddPolicy("MyCors", builder =>
    {
        builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });

});// add the employee repository to the Di 
 builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
 builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("MyCors");

app.MapControllers();
app.Run();
