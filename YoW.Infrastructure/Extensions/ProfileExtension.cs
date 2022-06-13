using AutoMapper;

namespace YoW.Infrastructure.Extensions
{
  public static class ProfileExtension
  {
    public static IMappingExpression<TSource, TDest> WithCollection<TSource, TDest>(this IMappingExpression<TSource, TDest> mapping, Profile profile)
    {
      profile.CreateMap<ICollection<TSource>, ICollection<TDest>>();
      return mapping;
    }
  }
}
