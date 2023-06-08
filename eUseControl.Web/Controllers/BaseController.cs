using System;
using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
     public class BaseController : Controller
     {
          public readonly ISession _session;
          // GET: Base
          public BaseController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBl();
          }
          public void SessionStatus()
          {
               var apiCookie = Request.Cookies["X-KEY"];
               if (apiCookie != null)
               {
                    var uProfile = _session.GetUserByCookie(apiCookie.Value);
                    if (uProfile != null)
                    {
                         System.Web.HttpContext.Current.Session.Add("__SessionObject", uProfile);
                         System.Web.HttpContext.Current.Session["LoginStatus"] = "login";

                    }
                    else
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
                    }
               }
               else
               {
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
               }
          }

          public void GetUsername()
          {
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = (UserMinimal)System.Web.HttpContext.Current?.Session["__SessionObject"];
                    if (user != null) ViewBag.Username = user.Username;
               }
               else
               {
                    ViewBag.Username = "Guest";
               }
          }
          public void GetUserId()
          {
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = (UserMinimal)System.Web.HttpContext.Current?.Session["__SessionObject"];
                    if (user != null) ViewBag.UserId = user.Id;
               }
          }
          public void GetUserLevel()
          {
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = (UserMinimal)System.Web.HttpContext.Current?.Session["__SessionObject"];
                    if (user != null)
                         switch (user.Level)
                         {
                              case URole.Admin:
                                   ViewBag.UserLevel = "Admin";
                                   break;
                              case URole.Trainer:
                                   ViewBag.UserLevel = "Trainer";
                                   break;
                              case URole.User:
                                   ViewBag.UserLevel = "User";
                                   break;
                              default:
                                   ViewBag.UserLevel = "Guest";
                                   break;
                         }
               }
          }

          public UserSettings GetUserMinimal()
          {
               GetUserLevel();
               var apiCookie = Request.Cookies["X-KEY"];
               if (apiCookie != null)
               {
                    var uProfile = _session.GetUserByCookie(apiCookie.Value);
                    return new UserSettings
                    {
                         Id = uProfile.Id,
                         Email = uProfile.Email,
                         Username = uProfile.Username,
                         Privilege = ViewBag.UserLevel,
                         CurrentPassword = "",
                         Password1 = "",
                         Password2 = "",
                    };
               }
               return new UserSettings();

          }

          public void GetUserData()
          {
               SessionStatus();
               GetUsername();
               GetUserLevel();
               GetUserId();
          }
     }
}
