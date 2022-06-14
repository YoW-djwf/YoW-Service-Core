using Microsoft.EntityFrameworkCore.Design;

namespace YoW.Infrastructure.EntityFramework
{
  public class AppDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : AppDbContextBase
  {
    public TContext CreateDbContext(string[] args)
    {
      throw new NotImplementedException();
    }
  }
}
