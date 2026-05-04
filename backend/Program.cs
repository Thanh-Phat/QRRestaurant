using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QRRestaurant_backend.Data;
using QRRestaurant_backend.Services.Implement;
using QRRestaurant_backend.Services.Interfaces;
using System.Runtime.CompilerServices;

// Load .env 
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Lấy connection string từ .env
var connectionString = Environment.GetEnvironmentVariable("DB_ConnectionString");

// fallback nếu không có 
connectionString ??= builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string not found.");
}

// Add DbContext
// Fix for CS1955 and CS1026: 
// - UseSqlService should be UseSqlServer (assuming SQL Server is intended, based on EF Core conventions)
// - builder.Configuration is a property, not a method. Pass connectionString directly.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ITableService, TableService>();

// CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// bật CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();