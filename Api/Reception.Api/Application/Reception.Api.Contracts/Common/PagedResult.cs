using System.Collections.Generic;

namespace Reception.Contracts.Common
{
    /// <summary>
    /// Результат с информацией об общем количестве записей.
    /// </summary>
    /// <typeparam name="TData">Тип элементов.</typeparam>
    public class PagedResult<TData>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="PagedResult{TData}"/>
        /// </summary>
        /// <param name="total">Всего записей удовлетворяющих запросу.</param>
        /// <param name="items">Элементы соответствующие фильтру и параметрам пагинации.</param>
        public PagedResult(int total, IReadOnlyCollection<TData> items)
        {
            Total = total;
            Items = items;
        }

        ///<summary> 
        /// Общее количество записей согласно фильтру без пагинации.
        /// </summary>
        public int Total { get; set; }

        ///<summary>
        /// Записи, соответствующие фильтру.
        ///</summary>
        public IReadOnlyCollection<TData> Items { get; set; }
    }
}
