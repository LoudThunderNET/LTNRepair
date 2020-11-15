using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reception.Handlers.Order.Queries;

namespace Reception.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetAction(int orderId, CancellationToken cancellation)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(orderId), cancellation);

            return Ok(order);
        }
    }
}
