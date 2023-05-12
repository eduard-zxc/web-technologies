using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;

namespace eUseControl.Web.Filters
{
     public class TrainerModAttribute : ActionFilterAttribute
     {
          private readonly ISession _session;
          public TrainerModAttribute()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
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
                         if (profile != null && (profile.Level == URole.Trainer || profile.Level == URole.Admin))
                         {
                              HttpContext.Current.Session.Add("__SessionObject", profile);
                              return;
                         }
                    }
               }
               filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
          }
     }
}