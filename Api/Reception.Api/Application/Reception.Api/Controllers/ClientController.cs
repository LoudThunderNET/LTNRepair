using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reception.Contracts.Reception;
using Reception.Handlers.Client.Queries;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediatr;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ClientController"/>.
        /// </summary>
        /// <param name="mediatr">Медиатор.</param>
        public ClientController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        /// <summary>
        /// Возвращает модель клиента по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Модель клиента.</returns>
        [ProducesResponseType(typeof(ClientDto), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellation)
        {
            return Ok(await _mediatr.Send(new GetClientByIdQuery(id), cancellation));
        }

        /// <summary>
        /// Возвращает коллекцию клиентов отфильтрованных по подстроке в наименовании.
        /// </summary>
        /// <param name="searchedSubstring">Подстрока поиска.</param>
        /// <param name="cancellation">Отмена задачи.</param>
        /// <returns>Модель клиента.</returns>
        [ProducesResponseType(typeof(IReadOnlyCollection<ClientDto>), (int)HttpStatusCode.OK)]
        [HttpGet("filtered/{searchedSubstring}")]
        public async Task<IActionResult> GetBySubstringAsync(string searchedSubstring, CancellationToken cancellation)
        {
            return Ok(await _mediatr.Send(new GetFilteredClientsQuery(searchedSubstring), cancellation));
        }
    }
}
