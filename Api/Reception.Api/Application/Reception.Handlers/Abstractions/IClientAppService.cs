using Reception.Contracts.Reception;
using Reception.Contracts.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Abstractions
{
    /// <summary>
    /// Сервис приложения для работы с клиентами.
    /// </summary>
    public interface IClientAppService
    {
        /// <summary>
        /// Возвращает модель клиента по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <param name="cancellation">Отмена задчаи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения модели клиента по его идентификатору.</returns>
        Task<ClientDto> GetAsync(int id, CancellationToken cancellation);

        /// <summary>
        /// Возвращает коллекцию клиентов соответствующих запросу.
        /// </summary>
        /// <param name="clientRequest">Запрос на отбор клиентов.</param>
        /// <param name="cancellation">Отмена задчаи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения коллекции клиентов соответствующих запросу.</returns>
        Task<IReadOnlyCollection<ClientDto>> GetFilteredAsync(ClientRequest clientRequest, CancellationToken cancellation);
    }
}