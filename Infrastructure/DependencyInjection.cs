using Domain.Common;
using Infrastructure.Common;
using Infrastructure.Data;
using Infrastructure.Data.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configurations)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
