using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Controllers;

namespace eUseControl.Web.Controllers
{
     public class HomeController : BaseController
     {
          public ActionResult Index()
          {

               SessionStatus();
               GetUsername();
               GetUserLevel();

               return View();
          }
     }

}