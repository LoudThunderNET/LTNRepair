using DataAccess.Abstraction;
using DataAccess.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reception.Domain.Services.Abstractions;

namespace DataAccess.EntityFramework.Dependency
{
    public static class DependencyExtensions
    {
        public static void AddEntityFramework<TDbContext>(this IServiceCollection services, string connectionString)
            where TDbContext : DbContext
        {
            services.AddTransient(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
            services.AddTransient(typeof(IMutableRepository<>), typeof(MutableRepository<>));
            services.AddTransient<ITransactionManager, TransactionManager>();
            services.AddScoped<DbContext, TDbContext>();

            services.AddDbContext<TDbContext>(options => 
            {
                options.EnableSensitiveDataLogging(true);
                options.UseSqlServer(connectionString);
            });
        }
    }
}
