using CQSR.Abstraction;
using Reception.Contracts.Common;
using Reception.Contracts.Reception;
using Reception.Handlers.Abstractions;
using Reception.Handlers.OrderRegistry.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.OrderRegistry.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение реестра заказов.
    /// </summary>
    public class GetOrderRegistryByFilterQueryHandler : IQueryHandler<GetOrderRegistryByFilterQuery, PagedResult<OrderRegistryItem>>
    {
        private IOrderRegistryService _orderRegistryService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetOrderRegistryByFilterQueryHandler"/>.
        /// </summary>
        /// <param name="orderRegistryService">Сервис реестра заказов.</param>
        public GetOrderRegistryByFilterQueryHandler(IOrderRegistryService orderRegistryService)
        {
            _orderRegistryService = orderRegistryService;
        }

        /// <inheritdoc/>
        public async Task<PagedResult<OrderRegistryItem>> Handle(GetOrderRegistryByFilterQuery request, CancellationToken cancellationToken)
        {
            int itemsCount = await _orderRegistryService.GetCountByFilterAsync(request.Request, cancellationToken);
            var items = await _orderRegistryService.GetByFilterAsync(request.Request, cancellationToken);

            return new PagedResult<OrderRegistryItem>(itemsCount, items);
        }
    }
}
