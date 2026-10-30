
using JWTAuthenticationAndAuthorization.Data;
using JWTAuthenticationAndAuthorization.IServices;
using JWTAuthenticationAndAuthorization.Middleware;
using JWTAuthenticationAndAuthorization.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .ConfigureJWTAuthentication(builder.Configuration)
    .ConfigureJWTAuthorization(builder.Configuration);

builder.Services.AddAuthorization();


builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
