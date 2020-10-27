using DataAccess.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    /// <summary>
    /// Реализация репозитория только для чтения.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, new()
    {
        private readonly DbContext _dbContext;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ReadOnlyRepository{TEntity}"/>.
        /// </summary>
        /// <param name="dbContext">Контекст БД.</param>
        public ReadOnlyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public Task<TEntity> FindAsync(Func<TEntity, int> keySelector, CancellationToken cancellation)
        {
            var objectSet = ((IObjectContextAdapter)_dbContext).ObjectContext.CreateObjectSet<TEntity>();
            //Act
            var keyName = objectSet.EntitySet.ElementType.KeyMembers.Select(k=>k.Name).SingleOrDefault();

        }

        public Task<IReadOnlyCollection<TEntity>> QueryCollectionAsync(IQueryable<TEntity> queryBulder, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> QueryFirstOrDefaultAsync(IQueryable<TEntity> queryBulder, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
