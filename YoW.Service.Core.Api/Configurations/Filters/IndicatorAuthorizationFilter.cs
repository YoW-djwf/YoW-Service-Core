using Microsoft.AspNetCore.Mvc.Filters;
using YoW.Infrastructure.Interfaces;

namespace YoW.Service.Core.Api.Configurations.Filters
{
  public class IndicatorAuthorizationFilter : IAuthorizationFilter
  {
    private readonly IAuditService auditService;

    public IndicatorAuthorizationFilter(IAuditService auditService)
    {
      this.auditService = auditService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
      auditService.UserName = context.HttpContext.User.Identity?.Name ?? "Unknown";
    }
  }
}