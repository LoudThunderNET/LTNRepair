using Common.Lib.Mapping;
using CQSR.Abstraction;
using Reception.Contracts.Reception;
using Reception.Handlers.Abstractions;
using Reception.Handlers.Equipment.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Equipment
{
    /// <summary>
    /// Обработчик запроса на получение коллекции оборудования согласно запросу.
    /// </summary>
    public sealed class GetEquipmentByRequestQueryHandler : IQueryHandler<GetEquipmentByRequestQuery, IReadOnlyCollection<EquipmentDto>>
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ITypeMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetEquipmentByRequestQueryHandler"/>.
        /// </summary>
        /// <param name="equipmentService">Доменный сервис оборудования.</param>
        /// <param name="mapper">Средство маппинга.</param>
        public GetEquipmentByRequestQueryHandler(IEquipmentService equipmentService, ITypeMapper mapper)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<EquipmentDto>> Handle(GetEquipmentByRequestQuery query, CancellationToken cancellation)
        {
            var equipments = await _equipmentService.GetByRequestAsync(query.Request, cancellation);

            return _mapper.MapAsReadOnlyCollection<Domain.Entities.Equipment, EquipmentDto>(equipments);
        }
    }
}
