using Common.Lib;
using Common.Lib.Mapping;
using Reception.AppServices.Abstractions;
using Reception.Contracts.Reception;
using Reception.Handlers.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.AppServices.Client
{
    /// <summary>
    /// Реализация сервиса приложения для работы с клиентами.
    /// </summary>
    public class ClientAppService : IClientAppService
    {
        private readonly IClientService _clientService;
        private readonly ITypeMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ClientAppService"/>.
        /// </summary>
        /// <param name="clientService">Сервис для работы с клиентам.</param>
        /// <param name="mapper">Средство маппинга.</param>
        public ClientAppService(IClientService clientService, ITypeMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        public async Task<ClientDto> GetAsync(int id, CancellationToken cancellation)
        {
            var client = await _clientService.GetOrDefaultAsync(id, cancellation) 
                ?? throw new EntityNotFoundException($"Клиент с идентификатором {id} не найден.");

            return _mapper.Map<ClientDto>(client);
        }
    }
}
