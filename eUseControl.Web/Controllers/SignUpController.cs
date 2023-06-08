using AutoMapper;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.BL;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;
using System;
using System.Web.Mvc;
using eUseControl.Domain.Enums;
using System.Web;

namespace eUseControl.Web.Controllers
{
     public class SignUpController : BaseController
     {
          private new readonly ISession _session;

          public SignUpController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBl();

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
                    if (register.IsTrainer)
                    {
                         data.Level = URole.Trainer;
                         var bl = new BussinesLogic();
                         var trainer = bl.GetTrainerBl();
                         int trainerId = trainer.TrainerCreate();
                         data.TrainerId = trainerId;

                    }
                    else
                    {
                         data.Level = URole.User;
                         data.TrainerId = null;
                    }

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
                         var userLogin = _session.UserLogin(data0);
                         if (userLogin.Status)
                         {
                              HttpCookie cookie = _session.GenCookie(data0.Credential);
                              ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                         }
                         else
                         {
                              ModelState.AddModelError("", userLogin.StatusMsg);

                         }
                    }
                    else
                    {
                         ModelState.AddModelError("", userRegister.StatusMsg);
                    }
                    if (register.IsTrainer)
                    {
                         return RedirectToAction("Edit", "Trainers", new { id = data.TrainerId });
                    }
                    else
                    {
                         return RedirectToAction("Index", "Home");
                    }
               }
               return View();
          }
     }
}