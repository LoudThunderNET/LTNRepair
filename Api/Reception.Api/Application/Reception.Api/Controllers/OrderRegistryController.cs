using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reception.Contracts.Common;
using Reception.Contracts.Reception;
using Reception.Contracts.Requests;
using Reception.Handlers.OrderRegistry.Queries;

namespace Reception.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с реестром заказов.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderRegistryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderRegistryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Возвращает записи реестра заказов согласно фильтру.
        /// </summary>
        /// <param name="request">Фильтр.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        [HttpPost]
        [ProducesResponseType(typeof(PagedResult<OrderRegistryItem>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFilter(OrderRegistryRequest request, CancellationToken cancellation)
        {
            var orderRegistry = await _mediator.Send(new GetOrderRegistryByFilterQuery(request), cancellation);

            return Ok(orderRegistry);
        }
    }
}
