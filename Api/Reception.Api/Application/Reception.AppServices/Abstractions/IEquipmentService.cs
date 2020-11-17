using Common.Lib.Monads;
using Reception.Contracts.Reception;
using Reception.Contracts.Requests;
using Reception.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.AppServices.Abstractions
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
        Task<Equipment> GetOrDefaultAsync(int id, CancellationToken cancellation);

        /// <summary>
        /// Возвращает доменную модель обрудования по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оборудования.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения доменной модели обрудования по его идентификатору.</returns>
        Task<IReadOnlyCollection<Equipment>> GetByRequestAsync(EquipmentRequest request, CancellationToken cancellation);
    }
}
