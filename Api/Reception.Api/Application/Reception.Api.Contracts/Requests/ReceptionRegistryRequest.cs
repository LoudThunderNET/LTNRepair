namespace Reception.Contracts.Requests
{
    /// <summary>
    /// Запрос на получение реестра заказов.
    /// </summary>
    public class OrderRegistryRequest
    {
        /// <summary>
        /// Подстрока наименования.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Статус заказа.
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Сколько записей пропустить.
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Размер страницы.
        /// </summary>
        public int Take { get; set; }
    }
}
