using Microsoft.Extensions.DependencyInjection;
using DataAccess.EntityFramework.Dependency;
using Microsoft.Extensions.Configuration;
using DataAccess.EntityFramework;
using Reception.Handlers.Abstractions;
using Reception.Domain.Services;
using AppServices.Abstractions;
using Common.Lib.Mapping;
using AutoMapper;
using Reception.Infrastructure;
using Reception.AppServices.Abstractions;
using Reception.AppServices;

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
            services.AddTransient<IEquipmentAppService, EquipmentAppService>();

            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IEquipmentService, EquipmentService>();

            return services;
        }
    }
}
