using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Заказ на ремонт.
    /// </summary>
    public class Order
    {
        public Order()
        {
            Parts = new HashSet<PartOrderItem>();
        }

        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        ///<summary>
        /// Дата создания/приемки.
        /// </summary>
        public DateTime CreationDate { get; set; }

        ///<summary>
        /// Клиент.
        /// </summary>
        public int ClientId { get; set; }

        ///<summary>
        /// Статус ремонта.
        /// </summary>
        public int StatusId { get; set; }

        ///<summary>
        /// Оборудование.
        /// </summary>
        public int EquipmentId { get; set; }

        ///<summary>
        /// Описание неисправности.
        ///</summary>
        public string DefectDescription { get; set; }

        ///<summary> 
        /// Описание внешнего вида.
        /// </summary>
        public string ExternalStateDescription { get; set; }

        ///<summary> 
        /// Результат диагностики.
        /// </summary>
        public string DiagnosticResult { get; set; }

        ///<summary> 
        /// Комплектация.
        /// </summary>
        public string Complectation { get; set; }

        ///<summary>
        /// Заказанные запчасти.
        /// </summary>
        public virtual ICollection<PartOrderItem> Parts { get; set; }

        ///<summary>
        /// Стоимость ремонта.
        /// </summary>
        public decimal? RepairCost { get; set; }

        ///<summary>
        /// Клиент.
        /// </summary>
        public virtual Client Client { get; set; }

        ///<summary>
        /// Статус ремонта.
        /// </summary>
        public virtual OrderStatus Status { get; set; }

        ///<summary>
        /// Оборудование.
        /// </summary>
        public virtual Equipment Equipment { get; set; }
    }
}
