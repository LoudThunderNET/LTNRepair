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
        private readonly IClientAppService _clientAppService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetClientByIdQueryHandler"/>.
        /// </summary>
        /// <param name="clientAppService">Сервис приложения для работы с клиентами.</param>
        public GetClientByIdQueryHandler(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        /// <inheritdoc/>
        public Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellation)
        {
            return _clientAppService.GetAsync(request.Id, cancellation);
        }
    }
}
