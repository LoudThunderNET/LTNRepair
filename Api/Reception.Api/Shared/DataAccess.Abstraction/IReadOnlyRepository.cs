using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Abstraction
{
    /// <summary>
    /// Репозиторий только для чтения.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity: class, new()
    {
        /// <summary>
        /// Возвращает сущность по её идентификатору.
        /// </summary>
        /// <param name="keySelector">Селектор ключа.</param>
        /// <param name="cancellation">Отмена задачи</param>
        /// <returns>Сущность.</returns>
        Task<TEntity> FindAsync(Func<TEntity, int> keySelector, CancellationToken cancellation);

        /// <summary>
        /// Возвращает коллекцию сущностей по запросу.
        /// </summary>
        /// <param name="queryBulder">Строитель запроса.</param>
        /// <param name="cancellation">Отмена задачи</param>
        /// <returns>Коллекцию сущностей по запросу.</returns>
        Task<IReadOnlyCollection<TEntity>> QueryCollectionAsync(IQueryable<TEntity> queryBulder, CancellationToken cancellation);

        /// <summary>
        /// Возвращает сущностm по запросу.
        /// </summary>
        /// <param name="queryBulder">Строитель запроса.</param>
        /// <param name="cancellation">Отмена задачи</param>
        /// <returns>Коллекцию сущностей по запросу.</returns>
        Task<TEntity> QueryFirstOrDefaultAsync(IQueryable<TEntity> queryBulder, CancellationToken cancellation);
    }
}
