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
        private readonly IEquipmentAppService _equipmentAppService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetEquipmentByRequestQueryHandler"/>.
        /// </summary>
        /// <param name="equipmentAppService">Сервис приложения для работы с оборудованием.</param>
        public GetEquipmentByRequestQueryHandler(IEquipmentAppService equipmentAppService)
        {
            _equipmentAppService = equipmentAppService;
        }

        /// <inheritdoc/>
        public Task<IReadOnlyCollection<EquipmentDto>> Handle(GetEquipmentByRequestQuery query, CancellationToken cancellation)
        {
            return _equipmentAppService.GetByRequestAsync(query.Request, cancellation);
        }
    }
}
