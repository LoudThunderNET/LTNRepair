using DataAccess.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.EntityFramework.Dependency
{
    public static class DependencyExtensions
    {
        public static void AddEntityFramework<TDbContext>(this IServiceCollection services, string connectionString)
            where TDbContext : DbContext
        {
            services.AddTransient(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
            services.AddTransient(typeof(IMutableRepository<>), typeof(MutableRepository<>));
            services.AddDbContext<TDbContext>(dbO=> 
            {
                dbO.EnableSensitiveDataLogging(true);
            });
        }
    }
}
