using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace YoW.Infrastructure.EntityFramework
{
  public static class AppDbContextExtension
  {
    public static DbContextOptionsBuilder UseAppDbContext<TContext>(this DbContextOptionsBuilder builder, IConfiguration configuration) where TContext : AppDbContextBase
    {
      builder.UseSqlServer(configuration.GetConnectionString("default"))
          .ReplaceService<IDesignTimeDbContextFactory<TContext>, AppDbContextFactory<TContext>>();
      return builder;
    }
  }
}