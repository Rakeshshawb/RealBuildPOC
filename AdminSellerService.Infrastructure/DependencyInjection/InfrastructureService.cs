using Microsoft.Extensions.DependencyInjection;
using AdminSellerService.Application.Interfaces;
using AdminSellerService.Infrastructure.Repositories;


namespace AdminSellerService.Infrastructure.DependencyInjection
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAdminSellerRepository, AdminSellerRepository>();
            return services;
        }
    }
}
