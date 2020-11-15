using Reception.Contracts.Common;
using System;

namespace Reception.Contracts.Reception
{
    /// <summary>
    /// Запись реестра заказов.
    /// </summary>
    public class OrderRegistryItem
    {
        ///<summary>
        /// Номер.
        /// </summary>
        public int Id { get; set; }

        ///<summary>
        /// Дата создания/приемки.
        /// </summary>
        public DateTime CreationDate { get; set; }

        ///<summary>
        /// Клиент.
        /// </summary>
        public ClientDto Client { get; set; }

        ///<summary>
        /// Статус ремонта.
        /// </summary>
        public EnumType Status { get; set; }

        ///<summary>
        /// Оборудование.
        /// </summary>
        public EquipmentDto Equipment { get; set; }

        ///<summary>
        /// Описание неисправности.
        ///</summary>
        public string DefectDescription { get; set; }

        ///<summary> 
        /// Описание внешнего вида.
        /// </summary>
        public string ExternalStateDescription { get; set;}

        ///<summary> 
        /// Результат диагностики.
        /// </summary>
        public string DiagnosticResult { get; set;}

        ///<summary> 
        /// Комплектация.
        /// </summary>
        public string Complectation { get; set;}

        ///<summary>
        /// Заказанные запчасти.
        /// </summary>
        public PartOrderItemDto[] Parts { get; set; }

        ///<summary>
        /// Стоимость ремонта.
        /// </summary>
        public int? RepairCost { get; set; }
    }
}
