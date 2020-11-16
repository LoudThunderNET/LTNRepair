using Reception.Contracts.Reception;
using Reception.Contracts.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Abstractions
{
    /// <summary>
    /// Сервис реестра заказов.
    /// </summary>
    public interface IOrderRegistryService
    {
        /// <summary>
        /// Возвращает заказы, согласно запросу.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellation">Отмена задачи</param>
        Task<IReadOnlyCollection<OrderRegistryItem>> GetByFilterAsync(OrderRegistryRequest request, CancellationToken cancellation);

        /// <summary>
        /// Возвращает общее количество заказов, согласно запросу без пагинации.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellation">Отмена задачи</param>s
        Task<int> GetCountByFilterAsync(OrderRegistryRequest request, CancellationToken cancellation);
    }
}
