using Microsoft.Extensions.DependencyInjection;
using DataAccess.EntityFramework.Dependency;
using Microsoft.Extensions.Configuration;
using DataAccess.EntityFramework;
using Reception.Handlers.Abstractions;
using Reception.Domain.Services;
using Common.Lib.Mapping;
using AutoMapper;
using Reception.Infrastructure;

namespace ComponentRegistrar
{
    /// <summary>
    /// Методы расширения для регистрации компонентов.
    /// </summary>
    public static class DependencyExtensions
    {
        /// <summary>
        /// Регистрирует компоненты инфраструктуры.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация.</param>
        /// <returns>Коллекция сервисов.</returns>
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

        /// <summary>
        /// Регистрирует доменные сервисы.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация.</param>
        /// <returns>Коллекция сервисов.</returns>
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IEquipmentService, EquipmentService>();

            return services;
        }
    }
}
