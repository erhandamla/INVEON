using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace INVEON.Web.Filters
{
    public class IsAdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session == null && !(bool)session.Contents["IsAdmin"])
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Account", "Login" }
                                });
            }
        }
    }
}