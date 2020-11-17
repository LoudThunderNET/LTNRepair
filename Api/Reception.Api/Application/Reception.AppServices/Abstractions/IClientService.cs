using Reception.Contracts.Requests;
using Reception.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.AppServices.Abstractions
{
    /// <summary>
    /// Сервис для работы с клиентам.
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Возвращает доменную модель клиента по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения доменной модели клиента по его идентификатору.</returns>
        Task<Client> GetOrDefaultAsync(int id, CancellationToken cancellation);

        /// <summary>
        /// Возвращает коллекцию доменных моделей клиентов соответствующих запросу.
        /// </summary>
        /// <param name="request">Запрос на получение клиентов.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения коллекцию доменных моделей клиентов соответствующих запросу.</returns>
        Task<IReadOnlyCollection<Client>> GetFilteredAsync(ClientRequest request, CancellationToken cancellation);
    }
}