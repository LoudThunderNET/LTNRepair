using Microsoft.EntityFrameworkCore;
using Reception.Domain.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Repositories
{
    /// <summary>
    /// Реализация репозитория только для чтения.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ReadOnlyRepository{TEntity}"/>.
        /// </summary>
        /// <param name="dbContext">Контекст БД.</param>
        public ReadOnlyRepository(DbContext dbContext)
        {
            DbSet = dbContext.Set<TEntity>();
        }

        /// <inheritdoc/>
        public async Task<TEntity> FindAsync(int key, CancellationToken cancellation)
        {
            return await DbSet.FindAsync(new object[] { key }, cancellation);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<TEntity>> QueryCollectionAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryBulder, CancellationToken cancellation)
        {
            return await queryBulder(DbSet).ToArrayAsync(cancellation);
        }

        /// <inheritdoc/>
        public async Task<TEntity> QueryFirstOrDefaultAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryBulder, CancellationToken cancellation)
        {
            return await queryBulder(DbSet).FirstOrDefaultAsync(cancellation);
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation)
        { 
            return await DbSet.AnyAsync(predicate, cancellation);
        }

        /// <inheritdoc/>
        public async Task<int> CountAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryBulder, CancellationToken cancellation)
        { 
            return await queryBulder(DbSet).CountAsync(cancellation);
        }
    }
}
