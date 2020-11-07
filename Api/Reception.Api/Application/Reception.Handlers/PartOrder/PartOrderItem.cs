using Reception.Handlers.Common;
using System;

namespace Reception.Handlers.PartOrder
{
    ///<summary> 
    /// Модель элемента заказа запчастей.
    /// </summary>
    public class PartOrderItem
    {
        ///<summary> 
        /// Идентификатор запчасти.
        /// </summary>
        public int Id { get; set; }

        ///<summary> 
        /// Наименование запчасти.
        /// </summary>
        public string Name { get; set; }

        ///<summary> 
        /// Статус заказа.
        /// </summary>
        public EnumType Status { get; set; }

        ///<summary> 
        /// Ожидаемая дата.
        /// </summary>
        public DateTime ExpectedDeliveryDate { get; set; }
    }
}
