using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;

namespace DoubleCode.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        /*   

         Add-Migration Name -OutputDir Migrations -Context ApplicationDbContext -Project DoubleCode.Infrastructure
          Update-Database  -Context ApplicationDbContext 
         */
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DoubleCodeConnection"));
        });
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return services;

    }
}
