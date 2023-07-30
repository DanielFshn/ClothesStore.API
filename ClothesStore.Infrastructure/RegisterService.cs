using ClothesStore.Infrastructure.DatabaseContext;
using ClothesStrore.Application.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Infrastructure
{
    public static class RegisterService
    {
        public static void ConfigurationInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {


            var key = Encoding.ASCII.GetBytes(configuration["JWT:Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddDbContext<ClothesStoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ClothesStoreConnection"));
            });
            services.AddScoped<IMyDbContext>(options =>
            {
                return options.GetService<ClothesStoreDbContext>();
            });
        }
    }
}
