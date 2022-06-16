using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YoW.Entities.Abstracts;

namespace YoW.Service.Core.EntityFramework.Entities
{
  public class Tenant : FullObjectModel
  {
    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Metadata { get; set; } = "{}";

    public bool IsGlobalTenant { get; set; } = false;

    public Guid? GlobalTenantId { get; set; }
    public virtual Tenant? GlobalTenant { get; set; }
    public virtual ICollection<Tenant> Tenants { get; set; } = new HashSet<Tenant>();

    [NotMapped]
    public JObject Configuration
    {
      get => JObject.Parse(Metadata);
      set => Metadata = value.ToString();
    }

    public virtual void SaveConfig() => Metadata = Configuration.ToString();
  }
}
