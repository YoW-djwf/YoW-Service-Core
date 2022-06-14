using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using YoW.Service.Core.Api.Configurations.Filters;

namespace YoW.Service.Core.Api.Configurations
{
  public static class ControllersConfiguration
  {
    public static WebApplicationBuilder AddControllersConfiguration(this WebApplicationBuilder builder)
    {
      builder.Services.AddRouting(cfg =>
      {
        cfg.LowercaseUrls = true;
        cfg.LowercaseQueryStrings = true;
      });

      builder.Services.AddControllers(cfg =>
      {
        cfg.Filters.Add<IndicatorAuthorizationFilter>();
        cfg.Filters.Add<GlobalActionHandlingFilter>();
        cfg.Filters.Add<GlobalExceptionHandlingFilter>();
      }).AddNewtonsoftJson(cfg =>
      {
        cfg.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        cfg.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        cfg.SerializerSettings.Formatting = Formatting.Indented;
        cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      });

      return builder;
    }

    public static WebApplication UseControllersConfiguration(this WebApplication app)
    {
      app.UseStaticFiles();
      app.UseRouting();
      app.UseEndpoints(cfg =>
      {
        cfg.MapControllers();
      });

      return app;
    }
  }
}
