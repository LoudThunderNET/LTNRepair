using AutoMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Common.Lib.Mapping
{
    /// <summary>
    /// Реализация средства маппинга.
    /// </summary>
    public class TypeMapper : ITypeMapper
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="TypeMapper"/>.
        /// </summary>
        /// <param name="mapper">Экземпляр AutoMapper.</param>
        public TypeMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        /// <inheritdoc/>
        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            _mapper.Map(source, destination);
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<TDestination> MapAsReadOnlyCollection<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return new ReadOnlyCollection<TDestination>(_mapper.Map<TDestination[]>(source));
        }
    }
}