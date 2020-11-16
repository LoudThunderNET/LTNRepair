using Reception.Contracts.Reception;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Client.Abstractions
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
    }
}