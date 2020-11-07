using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Тип клиента.
    /// </summary>
    public class ClientType
    {
        public ClientType()
        {
            Clients = new HashSet<Client>();
        }

        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование типа.
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
