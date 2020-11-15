using CQSR.Abstraction;
using Reception.Contracts.Common;
using Reception.Contracts.Reception;
using Reception.Contracts.Requests;

namespace Reception.Handlers.OrderRegistry.Queries
{
    /// <summary>
    /// Запрос на получение реестра заказов.
    /// </summary>
    public class GetOrderRegistryByFilterQuery : IQuery<PagedResult<OrderRegistryItem>>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetOrderRegistryByFilterQuery"/>.
        /// </summary>
        /// <param name="request">Запрос на получение реестра заказов.</param>
        public GetOrderRegistryByFilterQuery(OrderRegistryRequest request)
        {
            Request = request;
        }

        /// <summary>
        /// Запрос на получение реестра заказов.
        /// </summary>
        public OrderRegistryRequest Request { get; }
    }
}
