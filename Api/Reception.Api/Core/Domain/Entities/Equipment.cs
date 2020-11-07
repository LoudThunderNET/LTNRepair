using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Оборудование.
    /// </summary>
    public class Equipment
    {
        public Equipment()
        {
            Orders = new HashSet<Order>();
            Complectations = new HashSet<Complectation>();
        }

        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на родительскую запись.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Признак группы.
        /// </summary>
        public bool IsNode { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Complectation> Complectations { get; set; }
    }
}
