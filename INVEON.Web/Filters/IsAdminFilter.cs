using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace INVEON.Web.Filters
{
    public class IsAdminFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session.Contents["UserName"] == null)
            {
                var values = new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "Account"
                });
                filterContext.Result = new RedirectToRouteResult(values);
            }
            if (session.Contents["IsAdmin"] != null && !(bool)session.Contents["IsAdmin"])
            {
               
                var values = new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "Account"
                });
                filterContext.Result = new RedirectToRouteResult(values);
            }
            base.OnActionExecuting(filterContext);
        }
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    HttpSessionStateBase session = filterContext.HttpContext.Session;
        //    if (session == null || !(bool)session.Contents["IsAdmin"])
        //    {
        //        filterContext.Result = new RedirectToRouteResult(
        //            new RouteValueDictionary {
        //                        { "Account", "Login" }
        //                        });
        //    }
        //}
    }
}