using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace INVEON.Web.Controllers
{
    public class AdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Account", "Login" }
                                });
            }
        }
    }
}