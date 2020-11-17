using CQSR.Abstraction;
using Reception.Contracts.Reception;

namespace Reception.Handlers.Equipment.Queries
{
    /// <summary>
    /// Запрос на получение модели оборудования по его идентификатору.
    /// </summary>
    public class GetEquipmentByIdQuery : IQuery<EquipmentDto>
    {
        /// <summary>
        /// Идентификатор оборудования.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="GetClientByIdQuery"/>.
        /// </summary>
        /// <param name="id">Идентификатор оборудования.</param>
        public GetEquipmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}