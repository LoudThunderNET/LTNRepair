using Common.Lib.Mapping;
using CQSR.Abstraction;
using Reception.Contracts.Common;
using Reception.Contracts.Reception;
using Reception.Handlers.Abstractions;
using Reception.Handlers.OrderRegistry.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.OrderRegistry
{
    /// <summary>
    /// Обработчик запроса на получение реестра заказов.
    /// </summary>
    public class GetOrderRegistryByFilterQueryHandler : IQueryHandler<GetOrderRegistryByFilterQuery, PagedResult<OrderRegistryItem>>
    {
        private readonly IOrderService _orderService;
        private readonly ITypeMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetOrderRegistryByFilterQueryHandler"/>.
        /// </summary>
        /// <param name="orderService">Доменный сервис заказов.</param>
        /// <param name="mapper">Средство маппинга.</param>
        public GetOrderRegistryByFilterQueryHandler(IOrderService orderService, ITypeMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<PagedResult<OrderRegistryItem>> Handle(GetOrderRegistryByFilterQuery query, CancellationToken cancellation)
        {
            int itemsCount = await _orderService.GetOrdersCountByRequestAsync(query.Request, cancellation);
            var orders = await _orderService.GetOrdersByRequestAsync(query.Request, cancellation);
            var items =_mapper.MapAsReadOnlyCollection<Domain.Entities.Order, OrderRegistryItem>(orders);

            return new PagedResult<OrderRegistryItem>(itemsCount, items);
        }
    }
}
