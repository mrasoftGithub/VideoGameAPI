using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameAPI.Data;

// NET 9 Web API & Entity Framework 🚀 Full Course: CRUD, Code-First Migrations & SQL Server
// https://localhost:7259/scalar/v1
// - Patrick God

// All Relationships with Entity Framework & Code-First Migrations in .NET 9 🚀
// https://www.youtube.com/watch?v=kMewc-TjO2s
// - Patrick God

// Link Scalar:
// https://localhost:7259/scalar/v1

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VideoGameDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
