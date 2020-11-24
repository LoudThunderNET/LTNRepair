using Common.Lib;
using Common.Lib.Mapping;
using CQSR.Abstraction;
using Reception.Contracts.Reception;
using Reception.Handlers.Abstractions;
using Reception.Handlers.Order.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Order
{
    /// <summary>
    /// Обработчик запроса на получение элемента реестра заказов по его идентификатору.
    /// </summary>
    public sealed class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderRegistryItem>
    {
        private readonly IOrderService _orderService;
        private readonly ITypeMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetOrderByIdQueryHandler"/>.
        /// </summary>
        /// <param name="orderService">Доменный сервис заказов.</param>
        /// <param name="mapper">Средство маппинга.</param>
        public GetOrderByIdQueryHandler(IOrderService orderService, ITypeMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<OrderRegistryItem> Handle(GetOrderByIdQuery request, CancellationToken cancellation)
        {
            var order = await _orderService.GetOrderByIdAsync(request.OrderId, cancellation)
                ?? throw new EntityNotFoundException($"Заказ с идентификатором {request.OrderId} не найден");

            return _mapper.Map<OrderRegistryItem>(order);
        }
    }
}
