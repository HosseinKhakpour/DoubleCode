using DoubleCode.Application.Interfaces.Accounts;
using DoubleCode.Application.Interfaces.IUserManagement;
using DoubleCode.Application.Services.Accounts;
using DoubleCode.Application.Services.UserManagement;
using DoubleCode.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.IOC
{
    public static class Container
    {
        public static IServiceCollection AddIOCServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DoubleCodeContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DoubleCodeConnection"));
            });

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserManagementService, UserManagementService>();


            return services;
        }
    }
}