using ClothesStrore.Application.Behaviors;
using ClothesStrore.Application.Common.Email;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace ClothesStrore.Application;

public static class RegisterService
{
    public static void ConfigurationApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(_ => _.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        services.AddScoped<IEmailService, EmailService>();
        services.AddHttpContextAccessor();
    }

}
