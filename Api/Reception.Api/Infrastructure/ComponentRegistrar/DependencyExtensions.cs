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
using Reception.AppServices.Client;
using Reception.Handlers.Client.Abstractions;
using Reception.AppServices.Abstractions;

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
            services.AddTransient<IOrderAppService, ReceptionAppService>();
            services.AddTransient<IOrderRegistryService, ReceptionAppService>();
            services.AddTransient<IClientAppService, ClientAppService>();

            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IClientService, ClientService>();

            return services;
        }
    }
}
