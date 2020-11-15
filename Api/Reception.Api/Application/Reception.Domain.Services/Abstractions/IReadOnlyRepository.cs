using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Domain.Services.Abstractions
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
        Task<TEntity> FindAsync(int key, CancellationToken cancellation);

        /// <summary>
        /// Возвращает коллекцию сущностей по запросу.
        /// </summary>
        /// <param name="queryBulder">Строитель запроса.</param>
        /// <param name="cancellation">Отмена задачи</param>
        /// <returns>Коллекцию сущностей по запросу.</returns>
        Task<IReadOnlyCollection<TEntity>> QueryCollectionAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryBulder, CancellationToken cancellation);

        /// <summary>
        /// Возвращает сущностm по запросу.
        /// </summary>
        /// <param name="queryBulder">Строитель запроса.</param>
        /// <param name="cancellation">Отмена задачи</param>
        /// <returns>Коллекцию сущностей по запросу.</returns>
        Task<TEntity> QueryFirstOrDefaultAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryBulder, CancellationToken cancellation);

        /// <summary>
        /// Сообщает есть ли записи удовлетворяющие запросу <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">Предикат условия.</param>
        /// <param name="cancellation">ОТмена задачи.</param>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation);

        /// <summary>
        /// Возвращает количество записей удовлетворяющих запросу.
        /// </summary>
        /// <param name="queryBulder">Предикат условия.</param>
        /// <param name="cancellation">Отмена задачи</param>
        /// <returns>Коллекцию сущностей по запросу.</returns>
        Task<int> CountAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryBulder, CancellationToken cancellation);
    }
}
