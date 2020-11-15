using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using Reception.Domain.Services.Abstractions;

namespace DataAccess.EntityFramework.Repositories
{
    /// <summary>
    /// Реализация изменяемого репозитория.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public class MutableRepository<TEntity> : ReadOnlyRepository<TEntity>, IMutableRepository<TEntity> where TEntity : class, new()
    {
        private readonly DbContext _dbContext;

        /// <summary>
        /// Инициализирует экземпляр <see cref="MutableRepository{TEntity}"/>.
        /// </summary>
        /// <param name="dbContext">Контекст БД.</param>
        public MutableRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellation)
        {
            await DbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellation);

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation)
        {
            await DbSet.AddRangeAsync(entities, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);

            return entities;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(TEntity entity, CancellationToken cancellation)
        {
            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellation);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation)
        {
            var entities = await DbSet.Where(predicate).ToArrayAsync(cancellation);
            await DeleteRangeAsync(entities, cancellation);
        }

        /// <inheritdoc/>
        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation)
        {
            DbSet.RemoveRange(entities);
            await _dbContext.SaveChangesAsync(cancellation);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(TEntity entity, CancellationToken cancellation)
        {
            DbSet.Update(entity);
            await _dbContext.SaveChangesAsync(cancellation);
        }
    }
}
