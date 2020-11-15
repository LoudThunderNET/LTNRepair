using Reception.Contracts.Reception;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Abstractions
{
    /// <summary>
    /// Сервис приложения заказов.
    /// </summary>
    public interface IOrderAppService
    {
        /// <summary>
        /// Возвращает запись реестра заказов по её идентификатору <paramref name="orderId"/>.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения записи реестра заказов по её идентификатору <paramref name="orderId"/>.</returns>
        Task<OrderRegistryItem> GetOrderRegistryItemByIdAsync(int orderId, CancellationToken cancellation);
    }
}