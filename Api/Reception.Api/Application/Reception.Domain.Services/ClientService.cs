using Reception.AppServices.Abstractions;
using Reception.Domain.Entities;
using Reception.Domain.Services.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Domain.Services
{
    /// <summary>
    /// Доменный сервис клиентов.
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly IReadOnlyRepository<Client> _clientRepository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ClientService"/>.
        /// </summary>
        /// <param name="clientRepository">Репозиторий клиентов.</param>
        public ClientService(IReadOnlyRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <inheritdoc/>
        public async Task<Client> GetOrDefaultAsync(int id, CancellationToken cancellation)
        {
            var client = await _clientRepository.QueryFirstOrDefaultAsync(q => q.Where(c => c.Id == id), cancellation);

            return client;
        }
    }
}
