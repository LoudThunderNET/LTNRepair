using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reception.Contracts.Reception;
using Reception.Handlers.Order.Queries;

namespace Reception.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с заказом.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Инициализирует экземпляр <see cref="OrderController"/>.
        /// </summary>
        /// <param name="mediator">Медатор.</param>
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Вовзаращет модель заказа по его идентификатору.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Задача, представляющая асинзронную операцию получение модели заказа по его идентификатору.</returns>
        [ProducesResponseType(typeof(OrderRegistryItem), (int)HttpStatusCode.OK)]
        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(int orderId, CancellationToken cancellation)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(orderId), cancellation);

            return Ok(order);
        }
    }
}
