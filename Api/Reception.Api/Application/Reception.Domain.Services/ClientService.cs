using Microsoft.EntityFrameworkCore;
using Reception.Handlers.Abstractions;
using Reception.Contracts.Requests;
using Reception.Domain.Entities;
using Reception.Domain.Services.Abstractions;
using System.Collections.Generic;
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
        public async Task<IReadOnlyCollection<Client>> GetFilteredAsync(ClientRequest request, CancellationToken cancellation)
        {
            var clientds = await _clientRepository.QueryCollectionAsync(
                q =>
                {
                    var queryBuilder = q;
                    if (!string.IsNullOrEmpty(request.Name))
                    {
                        queryBuilder = queryBuilder.Where(c => c.Name.StartsWith(request.Name) ||
                                    c.FirstName.StartsWith(request.Name) ||
                                    c.LastName.StartsWith(request.Name) ||
                                    c.MiddleName.StartsWith(request.Name));
                        
                    }
                    queryBuilder = queryBuilder.Include(x => x.ClientType);

                    return queryBuilder;
                }, cancellation);

            return clientds;
        }

        /// <inheritdoc/>
        public async Task<Client> GetOrDefaultAsync(int id, CancellationToken cancellation)
        {
            var client = await _clientRepository.QueryFirstOrDefaultAsync(q => q.Where(c => c.Id == id), cancellation);

            return client;
        }
    }
}
