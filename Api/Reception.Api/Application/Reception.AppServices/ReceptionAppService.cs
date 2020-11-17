using AppServices.Abstractions;
using Common.Lib;
using Common.Lib.Mapping;
using Reception.Contracts.Reception;
using Reception.Contracts.Requests;
using Reception.Domain.Entities;
using Reception.Handlers.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.AppServices
{
    /// <summary>
    /// Реализация сервиса приемки заказов.
    /// </summary>
    public class ReceptionAppService : IOrderAppService, IOrderRegistryService
    {
        private readonly IOrderService _orderService;
        private readonly ITypeMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ReceptionAppService"/>.
        /// </summary>
        /// <param name="orderService">Доменный сервис заказов.</param>
        /// <param name="mapper">Средство маппинга.</param>
        public ReceptionAppService(IOrderService orderService, ITypeMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<OrderRegistryItem>> GetByFilterAsync(OrderRegistryRequest request, CancellationToken cancellation)
        {
            var orders = await _orderService.GetOrdersByRequestAsync(request, cancellation);

            return _mapper.MapAsReadOnlyCollection<Order, OrderRegistryItem>(orders);
        }

        /// <inheritdoc/>
        public Task<int> GetCountByFilterAsync(OrderRegistryRequest request, CancellationToken cancellation)
        {
            return _orderService.GetOrdersCountByRequestAsync(request, cancellation);
        }

        /// <inheritdoc/>
        public async Task<OrderRegistryItem> GetOrderRegistryItemByIdAsync(int orderId, CancellationToken cancellation)
        {
            Order order = await _orderService.GetOrderByIdAsync(orderId, cancellation)
                ?? throw new EntityNotFoundException($"Заказ с идентификатором {orderId} не найден");

            return _mapper.Map<OrderRegistryItem>(order);
        }
    }
}
