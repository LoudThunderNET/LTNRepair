using CQSR.Abstraction;
using Reception.Contracts.Reception;
using Reception.Handlers.Abstractions;
using Reception.Handlers.Order.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Order.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение элемента реестра заказов по его идентификатору.
    /// </summary>
    public sealed class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderRegistryItem>
    {
        private readonly IOrderAppService _orderAppService;

        public GetOrderByIdQueryHandler(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        /// <inheritdoc/>
        public Task<OrderRegistryItem> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return _orderAppService.GetOrderRegistryItemByIdAsync(request.OrderId, cancellationToken);
        }
    }
}
