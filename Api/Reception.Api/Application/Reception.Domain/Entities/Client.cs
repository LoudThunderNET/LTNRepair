using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reception.Domain.Entities
{
    /// <summary>
    /// Клиент.
    /// </summary>
    public class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип клиента.
        /// </summary>
        public int ClientTypeId { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// КПП.
        /// </summary>
        public string Kpp { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Ажрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        public virtual ClientType ClientType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
