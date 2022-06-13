using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace YoW.Service.Core.Api.Configurations;

public static class GzipCompressionConfiguration
{
  public static IServiceCollection AddGzipCompression(this IServiceCollection services)
  {
    services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
    services.AddResponseCompression();

    return services;
  }

  public static IApplicationBuilder UseGzipCompression(this IApplicationBuilder app)
  {
    app.UseResponseCompression();

    return app;
  }
}