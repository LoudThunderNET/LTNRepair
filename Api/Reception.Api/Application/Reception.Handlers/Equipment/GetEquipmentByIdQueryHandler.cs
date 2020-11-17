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
        private readonly IEquipmentAppService _equipmentAppService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetEquipmentByIdQueryHandler"/>.
        /// </summary>
        /// <param name="EquipmentAppService">Сервис приложения для работы с оборудованием.</param>
        public GetEquipmentByIdQueryHandler(IEquipmentAppService EquipmentAppService)
        {
            _equipmentAppService = EquipmentAppService;
        }

        /// <inheritdoc/>
        public Task<EquipmentDto> Handle(GetEquipmentByIdQuery request, CancellationToken cancellation)
        {
            return _equipmentAppService.GetAsync(request.Id, cancellation);
        }
    }
}
