using System;
using System.Linq;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
     public class LogoutController : BaseController
     {
          // GET: Logout
          public ActionResult Index()
          {

               System.Web.HttpContext.Current.Session.Clear();
               if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
               {
                    var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                         cookie.Expires = DateTime.Now.AddDays(-1);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    }
               }
               System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
               return RedirectToAction("Index", "Home");
          }
     }
}