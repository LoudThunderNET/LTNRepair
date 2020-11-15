using AutoMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Common.Lib.Mapping
{
    public class TypeMapper : ITypeMapper
    {
        private readonly IMapper _mapper;

        public TypeMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            _mapper.Map(source, destination);
        }

        public IReadOnlyCollection<TDestination> MapAsReadOnlyCollection<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return new ReadOnlyCollection<TDestination>(_mapper.Map<TDestination[]>(source));
        }
    }
}
