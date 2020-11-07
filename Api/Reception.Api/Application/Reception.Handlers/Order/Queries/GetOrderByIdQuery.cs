using CQSR.Abstraction;
using System.Collections.Generic;

namespace Reception.Handlers.Order.Queries
{
    /// <summary>
    /// Запрос на получение элемента реестра заказов по его идентификатору.
    /// </summary>
    public class GetOrderByIdQuery: IQuery<OrderRegistryItem>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetOrderByIdQuery"/>.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа.</param>
        public GetOrderByIdQuery(int orderId)
        {
            OrderId = orderId;
        }

        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public int OrderId { get; }
    }
}
