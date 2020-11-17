using CQSR.Abstraction;
using Reception.Contracts.Reception;
using System.Collections.Generic;

namespace Reception.Handlers.Client.Queries
{
    /// <summary>
    /// Запрос на получение модели клиента по подстроке.
    /// </summary>
    public class GetFilteredClientsQuery : IQuery<IReadOnlyCollection<ClientDto>>
    {
        /// <summary>
        /// Подстрока поиска.
        /// </summary>
        public string SearchedString { get; }

        /// <summary>
        /// Инициализирцет экземпляр <see cref="GetFilteredClientsQuery"/>.
        /// </summary>
        /// <param name="searchedString">Подстрока поиска.</param>
        public GetFilteredClientsQuery(string searchedString)
        {
            SearchedString = searchedString;
        }
    }
}