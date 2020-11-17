namespace Reception.Contracts.Requests
{
    /// <summary>
    /// Запрос на получение оборудования.
    /// </summary>
    public class EquipmentRequest
    {
        /// <summary>
        /// Отбирать группы.
        /// </summary>
        public bool? Node { get; set; }

        /// <summary>
        /// Отбирать элементы, принадлежащие родительским элементам.
        /// </summary>
        public int[] ParentIds { get; set; }

        /// <summary>
        /// Отбирать элементы наименование которых начинается с <see cref="Name"/>.
        /// </summary>
        public string Name { get; set; }
    }
}
