using Common.Lib;
using Common.Lib.Mapping;
using CQSR.Abstraction;
using Reception.Contracts.Reception;
using Reception.Handlers.Abstractions;
using Reception.Handlers.Client.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Client
{
    /// <summary>
    /// Обработчик запроса на получение модели клиента по его идентификатору.
    /// </summary>
    public class GetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientService _clientService;
        private readonly ITypeMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetClientByIdQueryHandler"/>.
        /// </summary>
        /// <param name="clientService">Сервис для работы с клиентам.</param>
        /// <param name="mapper">Средство маппинга.</param>
        public GetClientByIdQueryHandler(IClientService clientService, ITypeMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellation)
        {
            var client = await _clientService.GetOrDefaultAsync(request.Id, cancellation)
                ?? throw new EntityNotFoundException($"Клиент с идентификатором {request.Id} не найден.");

            return _mapper.Map<ClientDto>(client);
        }
    }
}
