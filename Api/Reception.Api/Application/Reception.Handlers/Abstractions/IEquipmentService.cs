using Reception.Contracts.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Abstractions
{
    /// <summary>
    /// Доменный сервис оборудования.
    /// </summary>
    public interface IEquipmentService
    {
        /// <summary>
        /// Возвращает доменную модель обрудования по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оборудования.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения доменной модели обрудования по его идентификатору.</returns>
        Task<Domain.Entities.Equipment> GetOrDefaultAsync(int id, CancellationToken cancellation);

        /// <summary>
        /// Возвращает коллекцию обрудования согласно запросу.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения коллекцию обрудования согласно запросу.</returns>
        Task<IReadOnlyCollection<Domain.Entities.Equipment>> GetByRequestAsync(EquipmentRequest request, CancellationToken cancellation);
    }
}
