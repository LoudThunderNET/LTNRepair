using Reception.Contracts.Requests;
using Reception.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AppServices.Abstractions
{
    /// <summary>
    /// Доменный сервис заказов.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Возвращает заказ по его идентификатору.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Заказ.</returns>
        Task<Order> GetOrderByIdAsync(int orderId, CancellationToken cancellation);

        /// <summary>
        /// Возвращает заказы согласно запросу.
        /// </summary>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <param name="request">Запрос.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения заказов по запросу.</returns>
        Task<IReadOnlyCollection<Order>> GetOrdersByRequestAsync(OrderRegistryRequest request, CancellationToken cancellation);

        /// <summary>
        /// Возвращает количество заказов согласно запросу.
        /// </summary>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <param name="request">Запрос.</param>
        /// <returns>Задача, представляющая асинхронную операцию получения заказов по запросу.</returns>
        Task<int> GetOrdersCountByRequestAsync(OrderRegistryRequest request, CancellationToken cancellation);
    }
}