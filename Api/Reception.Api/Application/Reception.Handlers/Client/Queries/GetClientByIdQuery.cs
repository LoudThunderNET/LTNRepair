using CQSR.Abstraction;
using Reception.Contracts.Reception;

namespace Reception.Handlers.Client.Queries
{
    /// <summary>
    /// Запрос на получение модели клиента по его идентификатору.
    /// </summary>
    public class GetClientByIdQuery : IQuery<ClientDto>
    {
        /// <summary>
        /// Идентификатор клиента.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Инициализирцет экземпляр <see cref="GetClientByIdQuery"/>.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        public GetClientByIdQuery(int id)
        {
            Id = id;
        }
    }
}