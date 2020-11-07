namespace Common.Lib.Mapping
{
    public interface ITypeMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        void Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
