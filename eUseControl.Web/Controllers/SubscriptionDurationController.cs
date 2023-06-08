using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.SubscriptionDuration;
using eUseControl.Web.Filters;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
     public class SubscriptionDurationController : BaseController
     {
          private readonly ISubscriptionDuration _subscriptionDetails;

          public SubscriptionDurationController()
          {
               var bl = new BussinesLogic();
               _subscriptionDetails = bl.GetsSubscriptionDurationBl();
          }

          public ActionResult CreateSubscriptionDuration()
          {
               GetUserData();

               return View();
          }
          [AdminMod]
          [HttpPost]
          public ActionResult CreateSubscriptionDuration(SubscriptionDuration subscription)
          {
               GetUserData();

               SubscriptionDurationDbTable data = new SubscriptionDurationDbTable()
               {
                    Id = subscription.Id,
                    Name = subscription.Name,
                    Months = subscription.Months,
                    Discount = subscription.Discount
               };

               var subscriptionCreate = _subscriptionDetails.AddSubscriptionDuration(data);
               if (subscriptionCreate.Status)
               {
                    return RedirectToAction("Index", "Home");
               }
               else
               {
                    ModelState.AddModelError("", subscriptionCreate.StatusMsg);
                    return RedirectToAction("Index", "Error");
               }
          }

     }
}