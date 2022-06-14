namespace YoW.Service.Core.Api.Configurations
{
  public static class CorsConfiguration
  {
    public static WebApplicationBuilder AddCorsConfiguration(this WebApplicationBuilder builder)
    {
      var allowedHosts = string.Empty;
      allowedHosts = builder.Configuration.GetValue<string>(nameof(allowedHosts));

      builder.Services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
          builder =>
          {
            builder.WithOrigins(allowedHosts.Split(';').Select(r => r.Trim()).ToArray())
              .AllowAnyMethod()
              .AllowAnyHeader();
          });
      });

      return builder;
    }

    public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
    {
      app.UseCors("CorsPolicy");

      return app;
    }
  }
}