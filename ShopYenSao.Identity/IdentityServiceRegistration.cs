﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShopYenSao.Application.Identity;
using ShopYenSao.Application.Models.Identity;
using ShopYenSao.Identity.DbContext;
using ShopYenSao.Identity.Models;
using ShopYenSao.Identity.Services;

namespace ShopYenSao.Identity;

public static class IdentityServiceRegistration
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<YenSaoIdentityDatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ShopYenSao")));

         
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<YenSaoIdentityDatabaseContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();


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