using Reception.Handlers.Abstractions;
using Reception.Contracts.Requests;
using Reception.Domain.Entities;
using Reception.Domain.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Domain.Services
{
    /// <summary>
    /// Реализация сервиса заказов.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IReadOnlyRepository<Order> _orderRepository;

        /// <summary>
        /// Инициализирует эксземпляр <see cref="OrderService"/>.
        /// </summary>
        /// <param name="orderRepository">Репозиторий заказов.</param>
        public OrderService(IReadOnlyRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <inheritdoc/>
        public Task<Order> GetOrderByIdAsync(int orderId, CancellationToken cancellation)
        {
            return _orderRepository.FindAsync(orderId, cancellation);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<Order>> GetOrdersByRequestAsync(OrderRegistryRequest request, CancellationToken cancellation)
        {
            var orders = await _orderRepository.QueryCollectionAsync(q => new OrderRegistryQueryBuilder().Init(q, request).BuildQuery().BuildPaging().Build(), 
                cancellation);

            return orders;
        }

        /// <inheritdoc/>
        public Task<int> GetOrdersCountByRequestAsync(OrderRegistryRequest request, CancellationToken cancellation)
        {
            return _orderRepository.CountAsync(q => new OrderRegistryQueryBuilder().Init(q, request).BuildQuery().Build(), cancellation);
        }

        class OrderRegistryQueryBuilder
        {
            private IQueryable<Order> _query;
            private OrderRegistryRequest _request;
            public OrderRegistryQueryBuilder Init(IQueryable<Order> query, OrderRegistryRequest request)
            {
                _query = query;
                _request = request;

                return this;
            }

            public OrderRegistryQueryBuilder BuildQuery()
            {
                if (_request.Status.HasValue)
                {
                    _query = _query.Where(o => o.StatusId == _request.Status.Value);
                }

                if (!string.IsNullOrEmpty(_request.Text))
                {
                    _query = _query.Where(o => o.Equipment.Name.StartsWith(_request.Text) ||
                        o.Client.Name.StartsWith(_request.Text) ||
                        o.Client.LastName.StartsWith(_request.Text));
                }

                return this;
            }

            public OrderRegistryQueryBuilder BuildPaging()
            {
                var take = _request.Take == 0 ? 10 : _request.Take;
                _query = _query.Skip(_request.Skip).Take(take);

                return this;
            }

            public IQueryable<Order> Build()
            {
                return _query;
            }
        }
    }
}
