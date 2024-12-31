using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Identity;
using ShopYenSao.Application.Models.Identity;
using ShopYenSao.Identity.Models;
using ShopYenSao.Persistence.DatabaseContext;
using ShopYenSao.Persistence.Repositories;

namespace ShopYenSao.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<YenSaoDatabaseContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("ShopYenSao"));
        });
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        
        services.Configure<JWTSettings>(configuration.GetSection("JwtSettings"));
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<YenSaoDatabaseContext>().AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();
        // services.AddTransient<IUserService, UserService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(u =>        
            u.TokenValidationParameters = new TokenValidationParameters
            {                
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience= true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtSettings:Key"]))
            });

        return services;
        
    }
}