namespace YoW.Service.Core.Api.Configurations
{
  public static class ServiceProviderConfiguration
  {
    public static WebApplicationBuilder UseServiceProviderFactory(this WebApplicationBuilder builder)
    {
      return builder;
    }
  }
}