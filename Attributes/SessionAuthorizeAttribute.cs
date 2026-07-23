using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Axis.Attributes
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public int RoleId { get; set; } = 0;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            if (userId == null) {
            
                context.Result = new RedirectToActionResult("Login", "Authentication", null);
            }
            
            if (RoleId != 0)
            {
                int? userrole = context.HttpContext.Session.GetInt32("RoleId");
                if (userrole == null)
                {
                    context.Result = new RedirectToActionResult("Login", "Authentication", null);
                }
                else if (userrole != RoleId)
                {
                    context.Result = new RedirectToActionResult("AccessDenied", "Authentication", null);
                }
            }
        }
    }
}
