using Common.Lib.Mapping;
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
        private readonly IClientService _clientService;
        private readonly ITypeMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetFilteredClientsQueryHandler"/>.
        /// </summary>
        /// <param name="clientAppService">Сервис приложения для работы с клиентами.</param>
        public GetFilteredClientsQueryHandler(IClientService clientService, ITypeMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<ClientDto>> Handle(GetFilteredClientsQuery request, CancellationToken cancellation)
        {
            var clients = await _clientService.GetFilteredAsync(new ClientRequest { Name = request.SearchedString }, cancellation);

            return _mapper.MapAsReadOnlyCollection<Domain.Entities.Client, ClientDto>(clients);
        }
    }
}