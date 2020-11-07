using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Запасные чати для заказа на ремонт.
    /// </summary>
    public class PartOrderItem
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на заказ на ремонт.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Запасная часть.
        /// </summary>
        public int SparePartId { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена (без доставки).
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Накладные расходы.
        /// </summary>
        public decimal? Charges { get; set; }

        public virtual Order Order { get; set; }
        public virtual SparePart SparePart { get; set; }
    }
}
