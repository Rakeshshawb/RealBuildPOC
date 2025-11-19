using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Repositories;


namespace UserService.Infrastructure.DependencyInjection
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
