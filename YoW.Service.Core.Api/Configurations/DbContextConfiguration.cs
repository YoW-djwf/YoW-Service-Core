using Microsoft.EntityFrameworkCore;
using YoW.Service.Core.EntityFramework;

namespace YoW.Service.Core.Api.Configurations;

public static class DbContextConfiguration
{
  public static WebApplicationBuilder AddDbContextConfiguration(this WebApplicationBuilder builder)
  {
    builder.Services.AddEntityFrameworkSqlServer()
      .AddSqlServer<AppDbContext>("default", opts => { }, opts => { });
    return builder;
  }

  public static IServiceScope MigrateDatabase(this IServiceScope scope)
  {
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    dbContext.Database.Migrate();

    return scope;
  }
}
