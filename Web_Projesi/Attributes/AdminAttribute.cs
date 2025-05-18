using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web_Projesi.Attributes
{
    public class AdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("UserRole");
            if (rol != "Admin")
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}