using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reception.Domain.Entities
{
    /// <summary>
    /// Запасная часть.
    /// </summary>
    public class SparePart
    {
        public SparePart()
        {
            OrderItems = new HashSet<PartOrderItem>();
            SpareParts = new HashSet<SparePart>();
        }

        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на родительскую запись.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Признак группы.
        /// </summary>
        public bool IsNode { get; set; }

        /// <summary>
        /// Цена (без доставки).
        /// </summary>
        public decimal Price { get; set; }

        public virtual SparePart Parent { get; set; }
        public virtual ICollection<PartOrderItem> OrderItems { get; set; }
        public virtual ICollection<SparePart> SpareParts { get; set; }
    }
}
