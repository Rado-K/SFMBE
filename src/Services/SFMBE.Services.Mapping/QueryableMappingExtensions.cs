namespace SFMBE.Services.Mapping
{
  using System;
  using System.Linq;
  using System.Linq.Expressions;
  using AutoMapper;
  using AutoMapper.QueryableExtensions;

  public static class QueryableMappingExtensions
  {
    public static IQueryable<TDestination> To<TDestination>(
        this IQueryable source,
        params Expression<Func<TDestination, object>>[] membersToExpand)
    {
      if (source == null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      return source.ProjectTo(AutoMapperConfig.MapperInstance.ConfigurationProvider, null, membersToExpand);
    }

    public static IQueryable<TDestination> To<TDestination>(
        this IQueryable source,
        object parameters)
    {
      if (source == null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      return source.ProjectTo<TDestination>(AutoMapperConfig.MapperInstance.ConfigurationProvider, parameters);
    }

    public static TDestination To<TDestination>(this object source)
    {
      if (source == null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      return AutoMapperConfig.MapperInstance.Map<TDestination>(source);
    }

    public static TDestination To<TSource, TDestination>(this TSource source, TDestination destination)
    {
      if (source == null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      return AutoMapperConfig.MapperInstance.Map(source, destination);
    }

    public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
    this IMappingExpression<TSource, TDestination> map,
    Expression<Func<TDestination, object>> selector)
    {
      map.ForMember(selector, config => config.Ignore());
      return map;
    }
  }
}
