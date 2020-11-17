using CQSR.Abstraction;
using Reception.Contracts.Reception;
using Reception.Contracts.Requests;
using System.Collections.Generic;

namespace Reception.Handlers.Equipment.Queries
{
    /// <summary>
    /// Запрос на получение коллекции оборудования согласно запросу.
    /// </summary>
    public class GetEquipmentByRequestQuery : IQuery<IReadOnlyCollection<EquipmentDto>>
    {
        /// <summary>
        /// Инцииализирует экземпляр <see cref="GetEquipmentByRequestQuery"/>.
        /// </summary>
        /// <param name="request">Запрос на получение оборудования.</param>
        public GetEquipmentByRequestQuery(EquipmentRequest request)
        {
            Request = request;
        }

        /// <summary>
        /// Запрос на получение оборудования.
        /// </summary>
        public EquipmentRequest Request { get; }
    }
}
