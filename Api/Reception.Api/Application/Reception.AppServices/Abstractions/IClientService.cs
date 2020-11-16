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
        Task<Domain.Entities.Client> GetOrDefaultAsync(int id, CancellationToken cancellation);
    }
}