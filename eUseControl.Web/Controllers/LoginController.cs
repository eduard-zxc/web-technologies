using System;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
     public class LoginController : BaseController
     {
          private new readonly ISession _session;

          public LoginController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBl();
          }

          // GET: Login
          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]

          public ActionResult Index(UserLogin login)
          {
               if (ModelState.IsValid)
               {
                    ULoginData data = new ULoginData
                    {
                         Credential = login.Credential,
                         Password = login.Password,
                         LoginIp = Request.UserHostAddress,
                         LoginDateTime = DateTime.Now
                    };

                    var userLogin = _session.UserLogin(data);
                    if (userLogin.Status)
                    {
                         HttpCookie cookie = _session.GenCookie(data.Credential);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userLogin.StatusMsg);
                         return View();
                    }
               }
               return View();
          }
     }
}