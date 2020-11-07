using System;
using System.Collections.Generic;
using System.Text;

namespace Reception.Handlers.Equipment
{
    /// <summary>
    /// Обрудование.
    /// </summary>
    public class EquipmentBase
    {
        /// <summary> Идентификатор обродования в справочнике </summary>
        public int Id { get; set; }
        /// <summary> Наименование </summary>
        public string Name { get; set; }
    }
}
