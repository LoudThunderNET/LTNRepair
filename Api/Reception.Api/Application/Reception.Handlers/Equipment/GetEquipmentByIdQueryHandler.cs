using Common.Lib;
using Common.Lib.Mapping;
using CQSR.Abstraction;
using Reception.Contracts.Reception;
using Reception.Handlers.Abstractions;
using Reception.Handlers.Equipment.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Reception.Handlers.Equipment
{
    /// <summary>
    /// Обработчик запроса на получение модели оборудования по его идентификатору.
    /// </summary>
    public sealed class GetEquipmentByIdQueryHandler : IQueryHandler<GetEquipmentByIdQuery, EquipmentDto>
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ITypeMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetEquipmentByIdQueryHandler"/>.
        /// </summary>
        /// <param name="equipmentService">Доменный сервис оборудования.</param>
        /// <param name="mapper">Средство маппинга.</param>
        public GetEquipmentByIdQueryHandler(IEquipmentService equipmentService, ITypeMapper mapper)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<EquipmentDto> Handle(GetEquipmentByIdQuery request, CancellationToken cancellation)
        {
            var equipment = await _equipmentService.GetOrDefaultAsync(request.Id, cancellation)
                ?? throw new EntityNotFoundException($"Оборудование с идентификатором {request.Id} не найдено.");

            return _mapper.Map<EquipmentDto>(equipment);
        }
    }
}
