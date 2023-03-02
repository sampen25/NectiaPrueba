using Microsoft.Extensions.DependencyInjection;
using Nectia.Transversal.Common;
using Nectia.Infrastructure.Data;
using Nectia.Infrastructure.Repository;
using Nectia.Application.Interface;
using Nectia.Application.Main;
using Nectia.Domain.Interface;
using Nectia.Domain.Core;
using Nectia.Infrastructure.Interface;
using Nectia.Transversal.Logging;
using Microsoft.Extensions.Configuration;

namespace Nectia.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
