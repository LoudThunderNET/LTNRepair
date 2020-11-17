using Common.Lib.Extensions;
using Reception.AppServices.Abstractions;
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
    /// Реализация доменного сервиса оборудования.
    /// </summary>
    public class EquipmentService : IEquipmentService
    {
        private readonly IReadOnlyRepository<Equipment> _equipmentRepository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="EquipmentService"/>.
        /// </summary>
        /// <param name="equipmentRepository">Репозиторий оборудования.</param>
        public EquipmentService(IReadOnlyRepository<Equipment> equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task<IReadOnlyCollection<Equipment>> GetByRequestAsync(EquipmentRequest request, CancellationToken cancellation)
        {
            return _equipmentRepository.QueryCollectionAsync(q=> 
            {
                var query = q;

                if (request.Node.HasValue)
                    query = query.Where(e => e.IsNode == request.Node.Value);

                query = request.ParentIds.IsNotEmpty()
                    ? query.Where(e => e.ParentId != null && request.ParentIds.Contains(e.ParentId.Value))
                    : query.Where(e => e.ParentId == null);

                if (!string.IsNullOrEmpty(request.Name))
                    query = query.Where(e => e.Name.StartsWith(request.Name));

                return query;
            }, cancellation);
        }

        /// <inheritdoc/>
        public Task<Equipment> GetOrDefaultAsync(int id, CancellationToken cancellation)
        {
            return _equipmentRepository.FindAsync(id, cancellation);
        }
    }
}
