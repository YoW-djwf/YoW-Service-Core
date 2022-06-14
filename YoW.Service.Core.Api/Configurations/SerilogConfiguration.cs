namespace YoW.Service.Core.Api.Configurations
{
  public static class SerilogConfiguration
  {
    public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
    {
      return builder;
    }
  }
}