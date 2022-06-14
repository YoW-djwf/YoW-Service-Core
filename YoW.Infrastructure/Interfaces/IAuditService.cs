namespace YoW.Infrastructure.Interfaces
{
  public interface IAuditService
  {
    public string UserName { get; set; }
    public Guid TenantId { get; set; }
  }
}
