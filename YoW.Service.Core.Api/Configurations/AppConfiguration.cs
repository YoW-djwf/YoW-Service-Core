namespace YoW.Service.Core.Api.Configurations
{
  public static class AppConfiguration
  {
    public static WebApplicationBuilder ConfigureAppConfiguration(this WebApplicationBuilder builder, string[] args)
    {
      builder.Host.ConfigureAppConfiguration((host, config) => {
        config.Sources.Clear();

        var evn = host.HostingEnvironment;

        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        config.AddJsonFile($"appsettings.{evn.EnvironmentName}.json", optional: true, reloadOnChange: true);

        config.AddEnvironmentVariables();

        if (args != null)
        {
          config.AddCommandLine(args);
        }

      });

      return builder;
    }

    public static WebApplicationBuilder AppInitialization(this WebApplicationBuilder builder)
    {
      return builder;
    }
  }
}
