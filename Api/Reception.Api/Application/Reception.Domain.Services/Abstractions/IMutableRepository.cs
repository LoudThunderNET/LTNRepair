using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Reception.Domain.Services.Abstractions
{
    /// <summary>
    /// Репозиторий с возможностью изменять данные.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IMutableRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Добавляет записи в БД на основе сущности.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Добавленная сущность.</returns>
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellation);

        /// <summary>
        /// Добавляет записи в БД на основе сущностей.
        /// </summary>
        /// <param name="entity">Сущности.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Добавленные сущности.</returns>
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation);

        /// <summary>
        /// Обновляет записи в БД на основе сущности.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Обновленная сущность.</returns>
        Task UpdateAsync(TEntity entity, CancellationToken cancellation);

        /// <summary>
        /// Удаляет записи в БД на основе сущности.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию удаления записей.</returns>
        Task DeleteAsync(TEntity entity, CancellationToken cancellation);

        /// <summary>
        /// Удаляет записи в БД удовлетворяющие предикату.
        /// </summary>
        /// <param name="predicate">Предикат.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию удаления записей.</returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation);

        /// <summary>
        /// Удаляет записи в БД на основе коллекции сущностей.
        /// </summary>
        /// <param name="entities">Коллекция сущностей.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию удаления записей.</returns>
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation);
    }
}
