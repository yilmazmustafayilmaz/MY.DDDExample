using Application.Common.Security;
using Domain.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddSingleton<IJwtOption>(x => x.GetRequiredService<IOptions<JwtOption>>().Value);
        services.AddSingleton<IJwtService, JwtService>();

        return services;
    }
}
