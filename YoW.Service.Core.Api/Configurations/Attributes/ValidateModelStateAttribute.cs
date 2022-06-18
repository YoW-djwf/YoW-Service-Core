using Microsoft.AspNetCore.Mvc.Filters;

namespace YoW.Service.Core.Api.Configurations.Attributes
{
  [AttributeUsage(AttributeTargets.Method, Inherited = false)]
  public class ValidateModelStateAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      //if (context.ModelState.IsValid)
      //{
      //    return;
      //}

      //throw new ValidationException(context.ModelState.GetErrors());
    }
  }
}
