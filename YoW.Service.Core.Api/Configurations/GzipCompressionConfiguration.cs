using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace YoW.Service.Core.Api.Configurations
{
  public static class GzipCompressionConfiguration
  {
    public static WebApplicationBuilder AddGzipCompression(this WebApplicationBuilder builder)
    {
      builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
      builder.Services.AddResponseCompression();

      return builder;
    }

    public static IApplicationBuilder UseGzipCompression(this IApplicationBuilder app)
    {
      app.UseResponseCompression();

      return app;
    }
  }
}