using Microsoft.Extensions.DependencyInjection;
using DataAccess.EntityFramework.Dependency;
using Microsoft.Extensions.Configuration;
using DataAccess.EntityFramework;
using AppServices.Reception;
using Reception.Handlers.Abstractions;
using Reception.Domain.Services;
using AppServices.Abstractions;
using Common.Lib.Mapping;
using AutoMapper;
using Reception.Infrastructure;

namespace ComponentRegistrar
{
    public static class DependencyExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddEntityFramework<ReceptionDbContext>(configuration.GetConnectionString("ReceptionDatabase"));
            services.AddTransient<ITypeMapper, TypeMapper>();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ReceptionMapping>();
            });

            return services;
        }
        
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderAppService, ReceptionService>();
            services.AddTransient<IOrderRegistryService, ReceptionService>();

            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderService, OrderService>();
            return services;
        }
    }
}
