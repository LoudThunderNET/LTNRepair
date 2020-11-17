using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reception.Contracts.Reception;
using Reception.Contracts.Requests;
using Reception.Handlers.Client.Queries;
using Reception.Handlers.Equipment.Queries;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IMediator _mediatr;

        /// <summary>
        /// Инициализирует экземпляр <see cref="EquipmentController"/>.
        /// </summary>
        /// <param name="mediatr">Медиатор.</param>
        public EquipmentController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        /// <summary>
        /// Возвращает модель оборудования по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оборудования.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Модель оборудования.</returns>
        [ProducesResponseType(typeof(EquipmentDto), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellation)
        {
            return Ok(await _mediatr.Send(new GetClientByIdQuery(id), cancellation));
        }

        /// <summary>
        /// Возвращает коллекцию оборудования согласно запросу.
        /// </summary>
        /// <param name="request">Запрос на получение коллекции оборудования.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Коллекция оборудования.</returns>
        [ProducesResponseType(typeof(IReadOnlyCollection<EquipmentDto>), (int)HttpStatusCode.OK)]
        [HttpPost("filtered")]
        public async Task<IActionResult> GetByRequestAsync(EquipmentRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediatr.Send(new GetEquipmentByRequestQuery(request), cancellation));
        }
    }
}
