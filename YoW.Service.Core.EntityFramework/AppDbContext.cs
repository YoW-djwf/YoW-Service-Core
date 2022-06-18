using Microsoft.EntityFrameworkCore;
using YoW.EntityFramework;
using YoW.Service.Core.EntityFramework.Entities;
using YoW.Service.Core.EntityFramework.EntityConfigurations;

namespace YoW.Service.Core.EntityFramework
{
  public class AppDbContext : AppDbContextBase
  {
    public DbSet<Tenant> Tenants { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public AppDbContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.ApplyConfiguration(new TenantConfiguration());
    }
  }
}
