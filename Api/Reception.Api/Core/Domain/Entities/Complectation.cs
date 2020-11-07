namespace Domain.Entities
{
    /// <summary>
    /// Варианты комплектации оборудования
    /// </summary>
    public class Complectation
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на обрудование
        /// </summary>
        public int EquipmentId { get; set; }

        /// <summary>
        /// Наименование предмета комплектации.
        /// </summary>
        public string Name { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
