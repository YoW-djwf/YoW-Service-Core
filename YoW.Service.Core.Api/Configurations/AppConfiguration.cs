namespace YoW.Service.Core.Api.Configurations;

public static class AppConfiguration
{
  public static WebApplicationBuilder UseAppConfiguration(this WebApplicationBuilder builder, string[] args)
  {
    builder.Host.ConfigureAppConfiguration((host, config) => {
      var evn = host.HostingEnvironment;

      if (args?.Any() ?? false)
      {
        config.AddCommandLine(args);
      }

    });

    return builder;
  }

  public static WebApplication AppInitialization(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();

    scope.MigrateDatabase();

    return app;
  }
}
