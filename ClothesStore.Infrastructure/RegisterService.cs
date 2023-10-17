using ClothesStore.Infrastructure.Auth.Jwt;
using ClothesStore.Infrastructure.Auth.Users;
using ClothesStore.Infrastructure.Categories;
using ClothesStore.Infrastructure.DatabaseContext;
using ClothesStore.Infrastructure.Files;
using ClothesStore.Infrastructure.Genders;
using ClothesStore.Infrastructure.Orders;
using ClothesStore.Infrastructure.ProductRatings;
using ClothesStore.Infrastructure.Products;
using ClothesStore.Infrastructure.Sizes;
using ClothesStore.Infrastructure.Stripe;
using ClothesStrore.Application.Categoty;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.Genders;
using ClothesStrore.Application.Orders;
using ClothesStrore.Application.Product;
using ClothesStrore.Application.ProductsRating;
using ClothesStrore.Application.Sizes;
using ClothesStrore.Application.Stripe;
using ClothesStrore.Application.UploadFile;
using ClothesStrore.Application.User;
using ClothesStrore.Application.User.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClothesStore.Infrastructure
{
    public static class RegisterService
    {
        public static void ConfigurationInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IProductRating, ProductRatingService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IOrderService, OrderService>();


            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddIdentity<Microsoft.AspNetCore.Identity.IdentityUser, Microsoft.AspNetCore.Identity.IdentityRole>()
                .AddEntityFrameworkStores<ClothesStoreDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(10));

            var key = Encoding.ASCII.GetBytes(configuration["JWT:Key"]);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserPolicy", policy =>
                {
                    policy.RequireRole("User");
                });
            });

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
