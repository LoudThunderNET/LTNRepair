using Reception.Contracts.Reception;
using Reception.Contracts.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Abstractions
{
    /// <summary>
    /// Сервис приложения для работы с оборудованием.
    /// </summary>
    public interface IEquipmentAppService
    {
        /// <summary>
        /// Возвращает модель оборудования по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оборудования.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения модели оборудования по его идентификатору.</returns>
        Task<EquipmentDto> GetAsync(int id, CancellationToken cancellation);

        /// <summary>
        /// Возвращает коллекцию оборудования согласно запросу.
        /// </summary>
        /// <param name="request">Запрос на получение коллекции оборудования.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения коллекции оборудования согласно запросу.</returns>
        Task<IReadOnlyCollection<EquipmentDto>> GetByRequestAsync(EquipmentRequest request, CancellationToken cancellation);
    }
}
