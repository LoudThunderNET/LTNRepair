using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Abstraction
{
    /// <summary>
    /// Репозиторий с возможностью изменять данные.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IMutableRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellation);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellation);

        Task UpdateAsync(TEntity entity, CancellationToken cancellation);
        Task DeleteAsync(TEntity entity, CancellationToken cancellation);
        Task DeleteRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellation);
    }
}
