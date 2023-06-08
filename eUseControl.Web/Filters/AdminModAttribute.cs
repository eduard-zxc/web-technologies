using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;

namespace eUseControl.Web.Filters
{
     public class AdminModAttribute : ActionFilterAttribute
     {
          private readonly ISession _session;
          public AdminModAttribute()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBl();
          }
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var adminSession = (UserMinimal)HttpContext.Current?.Session["__SessionObject"];

               if (adminSession != null)
               {

                    var cookie = HttpContext.Current.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                         var profile = _session.GetUserByCookie(cookie.Value);
                         if (profile != null && profile.Level == URole.Admin)
                         {
                              HttpContext.Current.Session.Add("__SessionObject", profile);
                              return;
                         }
                    }
               }
               filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Error", action = "Index" }));
          }
     }
}