using Microsoft.EntityFrameworkCore;
using YoW.Infrastructure.EntityFramework;
using YoW.Infrastructure.Interfaces;
using YoW.Service.Core.EntityFramework.Entities;
using YoW.Service.Core.EntityFramework.EntityConfigurations;

namespace YoW.Service.Core.EntityFramework
{
  public class AppDbContext : AppDbContextBase
  {
    public DbSet<Tenant> Tenants { get; set; }

    public AppDbContext(DbContextOptions options, IAuditService auditService)
      : base(options, auditService)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.ApplyConfiguration(new TenantConfiguration());
    }
  }
}
