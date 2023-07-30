using AutoMapper;
using ClothesStrore.Application.User;
using ClothesStrore.Application.User.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ClothesStrore.Application
{
    public static class RegisterService
    {
        public static void ConfigurationApplication(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMediatR(_ => _.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddScoped<IJwtTokenGenerator,JwtTokenGenerator>();
        }
    }
}
