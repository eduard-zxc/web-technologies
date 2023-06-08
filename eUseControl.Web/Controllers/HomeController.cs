using System;
using System.Collections.Generic;
using System.Web.Mvc;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
     public class HomeController : BaseController
     {
          public ISubscriptionDuration _subscription;
          public HomeController()
          {
               var bl = new BussinesLogic();
               _subscription = bl.GetsSubscriptionDurationBl();
          }
          public ActionResult Index()
          {
               GetUserData();
               int userId = Convert.ToInt32(ViewBag.UserId);
               ViewBag.UserId = userId;
               var subscriptions = _subscription.GetAllSubscriptionDuration();
               List<SubscriptionDuration> subscriptionData = new List<SubscriptionDuration>();
               foreach (var subscription in subscriptions)
               {
                    subscriptionData.Add(new SubscriptionDuration()
                    {
                         Id = subscription.Id,
                         Name = subscription.Name,
                         Months = subscription.Months,
                         Discount = subscription.Discount
                    });
               }
               return View(subscriptionData);
          }
     }

}