using AutoMapper;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Domain.Enums;

namespace eUseControl.Web.Controllers
{
     public class SignUpController : BaseController
     {
          private readonly ISession _session;

          public SignUpController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
          }

          // GET: Register
          public ActionResult Index()
          {

               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserSignUp register)
          {
               if (ModelState.IsValid)
               {
                    var config = new MapperConfiguration(cfg => {
                         cfg.CreateMap<UserSignUp, URegisterData>();
                    });
                    IMapper mapper = config.CreateMapper();
                    var data = mapper.Map<URegisterData>(register);

                    data.LoginIp = Request.UserHostAddress;
                    data.LoginDateTime = DateTime.Now;

                    var userRegister = _session.UserRegister(data);
                    if (userRegister.Status)
                    {
                         ULoginData data0 = new ULoginData
                         {
                              Credential = register.Username,
                              Password = register.Password,
                              LoginIp = Request.UserHostAddress,
                              LoginDateTime = DateTime.Now,
                         };
                         //HttpCookie cookie = _sessionBL.GenCookie(register.Username);
                         //ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userRegister.StatusMsg);
                         return View();
                    }
               }
               return View();
          }
     }
}