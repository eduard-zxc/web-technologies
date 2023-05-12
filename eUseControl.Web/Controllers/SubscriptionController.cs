using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Filters;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class SubscriptionController : BaseController
    {
         private readonly ISubscription _subscription;

         public SubscriptionController()
         {
              var bl = new BussinesLogic();
              _subscription = bl.GetSubscriptionBL();
         }
         // GET: Schedule
         public ActionResult Index()
         {

              SessionStatus();
              GetUsername();
              GetUserLevel();

               var subscriptions = _subscription.GetSubscriptionList();
              List<Subscription> subscriptionData = new List<Subscription>();
              foreach (var subscription in subscriptions)
              {
                   subscriptionData.Add(new Subscription
                   {
                        Id = subscription.Id,
                        Name = subscription.Name,
                        Description = subscription.Description,
                        Price = subscription.Price,
                        ImageUrl = subscription.ImageUrl
                   });
              }
              return View(subscriptionData);
         }

          [TrainerMod]
          //Create a new Subscription
          public ActionResult Create()
          {
               return View();
          }
          [HttpPost]
          public ActionResult Create(Subscription subscription)
         {
              SubscriptionUDbTable data = new SubscriptionUDbTable()
              {
                   Id = subscription.Id,
                   Name = subscription.Name,
                   Description = subscription.Description,
                   Price = subscription.Price,
                   ImageUrl = subscription.ImageUrl
              };

              var subscriptionCreate = _subscription.CreateSubscription(data);
              if (subscriptionCreate.Status)
              {
                   return RedirectToAction("Index", "Subscription");
              }
              else
              {
                   ModelState.AddModelError("", subscriptionCreate.StatusMsg);
                   return View();
              }
         }

          public RedirectToRouteResult Delete(int id)
          {
               var response = _subscription.DeleteSubscription(id);
               //!! add result response!!!
               return RedirectToAction("Index", "Subscription");
          }

          public ActionResult Details(int id)
          {

               ViewBag.id = id;
               var subscription = _subscription.GetSingleSubscription(id);
               var subs = new Subscription()
               {
                    Id = subscription.Id,
                    Name = subscription.Name,
                    Description = subscription.Description,
                    Price = subscription.Price,
                    ImageUrl = subscription.ImageUrl
               };

               return View(subs);
          }


          public ActionResult Edit(int id)
          {
               ViewBag.id = id;
               var subscription = _subscription.GetSingleSubscription(id);
               var subs = new Subscription()
               {
                    Id = subscription.Id,
                    Name = subscription.Name,
                    Description = subscription.Description,
                    Price = subscription.Price,
                    ImageUrl = subscription.ImageUrl
               };

               return View(subs);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(Subscription subscription)
          {
               SubscriptionUDbTable data = new SubscriptionUDbTable()
               {
                    Id = subscription.Id,
                    Name = subscription.Name,
                    Description = subscription.Description,
                    Price = subscription.Price,
                    ImageUrl = subscription.ImageUrl

               };

               var SubscriptionCreate = _subscription.UpdateSubscription(data);
               if (SubscriptionCreate.Status)
               {
                    return RedirectToAction("Index", "Subscription");
               }
               else
               {
                    ModelState.AddModelError("", SubscriptionCreate.StatusMsg);
                    return RedirectToAction("Index", "Subscription");
               }
          }

     }

}