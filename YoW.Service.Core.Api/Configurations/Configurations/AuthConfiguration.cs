namespace YoW.Service.Core.Api.Configurations.Configurations
{
  public static class AuthConfiguration
  {
    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddAuthentication("Cookies")
          .AddCookie("Cookies");

      services.AddAuthorization();

      return services;
    }

    public static IApplicationBuilder UseAuthConfiguration(this IApplicationBuilder builder)
    {
      builder.UseAuthentication();
      builder.UseAuthorization();

      return builder;
    }
  }
}