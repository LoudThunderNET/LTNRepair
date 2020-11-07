using Common.Lib;
using Common.Lib.Mapping;
using CQSR.Abstraction;
using DataAccess.Abstraction;
using Reception.Handlers.Order.Queries;
using System.Threading;
using System.Threading.Tasks;
using Db = Domain.Entities;

namespace Reception.Handlers.Order.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение элемента реестра заказов по его идентификатору.
    /// </summary>
    public sealed class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderRegistryItem>
    {
        private readonly IReadOnlyRepository<Db.Order> _orderRepositroy;
        private readonly ITypeMapper _mapper;

        public GetOrderByIdQueryHandler(
            IReadOnlyRepository<Db.Order> orderRepositroy, 
            ITypeMapper mapper)
        {
            _orderRepositroy = orderRepositroy;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<OrderRegistryItem> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepositroy.FindAsync(request.OrderId, cancellationToken) 
                ?? throw new EntityNotFoundException($"Заказ с идентификатором {request.OrderId} не найден");

            return _mapper.Map<Db.Order, OrderRegistryItem>(order);
        }
    }
}
