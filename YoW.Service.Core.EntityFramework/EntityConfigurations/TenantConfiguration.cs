using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoW.Service.Core.EntityFramework.Entities;

namespace YoW.Service.Core.EntityFramework.EntityConfigurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
  public void Configure(EntityTypeBuilder<Tenant> builder)
  {
    builder.HasIndex(r => r.Code).IsUnique();
    builder.HasIndex(r => r.Name).IsUnique();
    builder.HasOne(r => r.GlobalTenant)
      .WithMany(r => r.Tenants)
      .HasForeignKey(r => r.GlobalTenantId);
  }
}
