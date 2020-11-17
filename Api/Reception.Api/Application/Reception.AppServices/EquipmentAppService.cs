using Reception.Contracts.Reception;
using Reception.AppServices.Abstractions;
using Reception.Handlers.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Common.Lib.Mapping;
using Reception.Domain.Entities;
using Common.Lib;
using System.Collections.Generic;
using Reception.Contracts.Requests;

namespace Reception.AppServices
{
    /// <summary>
    /// Сервис приложения для работу с оборудованием.
    /// </summary>
    public class EquipmentAppService : IEquipmentAppService
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ITypeMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="EquipmentAppService"/>.
        /// </summary>
        /// <param name="equipmentService">Доменный сервис оборудования.</param>
        /// <param name="mapper">Средство маппинга.</param>
        public EquipmentAppService(IEquipmentService equipmentService, ITypeMapper mapper)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<EquipmentDto> GetAsync(int id, CancellationToken cancellation)
        {
            var equipment = await _equipmentService.GetOrDefaultAsync(id, cancellation) 
                ?? throw new EntityNotFoundException($"Оборудование с идентификтаором {id} не найдено.");

            return _mapper.Map<EquipmentDto>(equipment);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<EquipmentDto>> GetByRequestAsync(EquipmentRequest request, CancellationToken cancellation)
        {
            var equipments = await _equipmentService.GetByRequestAsync(request, cancellation);

            return _mapper.MapAsReadOnlyCollection<Equipment, EquipmentDto>(equipments);
        }
    }
}