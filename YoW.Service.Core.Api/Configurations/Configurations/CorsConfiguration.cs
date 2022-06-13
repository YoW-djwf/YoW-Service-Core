﻿namespace YoW.Service.Core.Api.Configurations.Configurations
{
  public static class CorsConfiguration
  {
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
      var allowedHosts = string.Empty;
      allowedHosts = configuration.GetValue<string>(nameof(allowedHosts));

      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
                  builder =>
                  {
                    builder.WithOrigins(allowedHosts.Split(';').Select(r => r.Trim()).ToArray())
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                  });
      });

      return services;
    }

    public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
    {
      app.UseCors("CorsPolicy");

      return app;
    }
  }
}