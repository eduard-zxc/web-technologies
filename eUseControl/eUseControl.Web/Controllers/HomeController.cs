using System;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
     public class HomeController : BaseController
     {
          public ActionResult Index()
          {
               GetUserData();
               int userId = Convert.ToInt32(ViewBag.UserId);
               ViewBag.UserId = userId;
               return View();
          }
     }

}