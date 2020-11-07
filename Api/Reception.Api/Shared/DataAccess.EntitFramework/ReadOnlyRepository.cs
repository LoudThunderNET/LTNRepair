using DataAccess.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ReadOnlyRepository{TEntity}"/>.
        /// </summary>
        /// <param name="dbContext">Контекст БД.</param>
        public ReadOnlyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        /// <inheritdoc/>
        public async Task<TEntity> FindAsync(int key, CancellationToken cancellation)
        {
            return await DbSet.FindAsync(key, cancellation);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<TEntity>> QueryCollectionAsync(Func<IQueryable<TEntity>, Task<IReadOnlyCollection<TEntity>>> queryBulder, CancellationToken cancellation)
        {
            return await queryBulder(DbSet);
        }

        /// <inheritdoc/>
        public async Task<TEntity> QueryFirstOrDefaultAsync(Func<IQueryable<TEntity>, Task<TEntity>> queryBulder, CancellationToken cancellation)
        {
            return await queryBulder(DbSet);
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation)
        { 
            return await DbSet.AnyAsync(predicate, cancellation);
        }
    }
}
