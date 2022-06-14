using System.ComponentModel.DataAnnotations;
using YoW.Infrastructure.Entities.Intefaces;

namespace YoW.Infrastructure.Entities.Abstracts;

public abstract class TenancyObjectModel : FullObjectModel, ITenancyModel
{
  [Required]
  public Guid TenantId { get; set; }
  public virtual Tenant Tenant { get; set; }
}
