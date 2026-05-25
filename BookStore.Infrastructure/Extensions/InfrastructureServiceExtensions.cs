using BookStore.Application.Interfaces;
using BookStore.Application.RepositoryInterfaces;
using BookStore.Domain.Settings;
using BookStore.Infrastructure.Authentication;
using BookStore.Infrastructure.Persistence.Context;
using BookStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // DB
        services.AddDbContext<BookStoreDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        // Identity
        services.AddIdentity<Microsoft.AspNetCore.Identity.IdentityUser,
            Microsoft.AspNetCore.Identity.IdentityRole>()
            .AddEntityFrameworkStores<BookStoreDbContext>();

        // JWT Settings
        services.Configure<JwtSettings>(
            configuration.GetSection("JwtSettings"));

        // JWT Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!))
            };
        });

        // Repositories
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}