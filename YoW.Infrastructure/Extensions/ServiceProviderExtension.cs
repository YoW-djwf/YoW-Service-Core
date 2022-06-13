using YoW.Infrastructure.Exceptions;

namespace YoW.Infrastructure.Extensions
{
  public static class ServiceProviderExtension
  {
    public static TService GetService<TService>(this IServiceProvider sp)
    {
      var serviceType = typeof(TService);
      var service = sp.GetService(serviceType);

      if (service == null)
      {
        throw new AppException($"{serviceType.Name} not found");
      }

      return (TService)service;
    }
  }
}
