using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

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
            _mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
