using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DoubleCode.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // Add any other services needed for the application

        return services;
    }
}

