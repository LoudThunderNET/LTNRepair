using CQSR.Abstraction;
using Reception.Contracts.Reception;
using Reception.Contracts.Requests;
using Reception.Handlers.Abstractions;
using Reception.Handlers.Client.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Client
{
    /// <summary>
    /// Обработчик запроса на получение модели клиента по его идентификатору.
    /// </summary>
    public sealed class GetFilteredClientsQueryHandler : IQueryHandler<GetFilteredClientsQuery, IReadOnlyCollection<ClientDto>>
    {
        private readonly IClientAppService _clientAppService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetFilteredClientsQueryHandler"/>.
        /// </summary>
        /// <param name="clientAppService">Сервис приложения для работы с клиентами.</param>
        public GetFilteredClientsQueryHandler(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        /// <inheritdoc/>
        public Task<IReadOnlyCollection<ClientDto>> Handle(GetFilteredClientsQuery request, CancellationToken cancellation)
        {
            return _clientAppService.GetFilteredAsync(new ClientRequest { Name = request.SearchedString }, cancellation);
        }
    }
}
