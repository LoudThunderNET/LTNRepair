using System.Collections.Generic;

namespace Common.Lib.Mapping
{
    /// <summary>
    /// Средство маппинга.
    /// </summary>
    public interface ITypeMapper
    {
        /// <summary>
        /// Преобразует значения объекта в <typeparamref name="TDestination"/>
        /// </summary>
        /// <typeparam name="TDestination">Тип целевого объект.</typeparam>
        /// <param name="source">Исходный объект.</param>
        /// <returns>Целевой объект.</returns>
        TDestination Map<TDestination>(object source);

        /// <summary>
        /// Преобразует коллекицию объектов <typeparamref name="TSource"/> в коллекцию для чтений объектов <typeparamref name="TDestination"/>.
        /// </summary>
        /// <typeparam name="TSource">Тип исходного объект.</typeparam>
        /// <typeparam name="TDestination">Тип целевого объект.</typeparam>
        /// <param name="source">Исходный объект.</param>
        /// <returns>Коллекция объектов целевого типа.</returns>
        IReadOnlyCollection<TDestination> MapAsReadOnlyCollection<TSource, TDestination>(IEnumerable<TSource> source);

        /// <summary>
        /// Преобразует значения объекта <typeparamref name="TSource"/> в <typeparamref name="TDestination"/>
        /// </summary>
        /// <typeparam name="TSource">Тип исходного объект.</typeparam>
        /// <typeparam name="TDestination">Тип целевого объект.</typeparam>
        /// <param name="source">Исходный объект.</param>
        /// <param name="destination">Целевой объект.</param>
        void Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
