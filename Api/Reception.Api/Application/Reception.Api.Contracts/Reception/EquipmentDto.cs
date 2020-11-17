namespace Reception.Contracts.Reception
{
    /// <summary>
    /// Обрудование.
    /// </summary>
    public class EquipmentDto
    {
        /// <summary> 
        /// Идентификатор обродования в справочнике 
        /// </summary>
        public int Id { get; set; }

        /// <summary> 
        /// Наименование 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Доступные опции комплектности.
        /// </summary>
        public string[]  AvailableComplectation { get; set; }

        /// <summary>
        /// Признак, что элемент является группой.
        /// </summary>
        public bool IsNode { get; set; }

        /// <summary>
        /// Ссылка на родительскую запись.
        /// </summary>
        public int? ParentId { get; set; }

    }
}
