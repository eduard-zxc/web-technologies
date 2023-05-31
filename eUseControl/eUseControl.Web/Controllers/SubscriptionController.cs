using System.Collections.Generic;
using System.Web.Mvc;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Subscription;
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
              _subscription = bl.GetSubscriptionBl();
         }
         // GET: Schedule
         public ActionResult Index()
         {
              GetUserData();



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

          //Create a new Subscription
          [AdminMod]
          public ActionResult Create()
          {
               GetUserData();

               return View();
          }
          [AdminMod]
          [HttpPost]
          public ActionResult Create(Subscription subscription)
         {
              GetUserData();

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
                   return RedirectToAction("Index", "Error");
              }
         }

          public RedirectToRouteResult Delete(int id)
          {
               GetUserData();

               _subscription.DeleteSubscription(id);
               //!! add result response!!!
               return RedirectToAction("Index", "Subscription");
          }

          public ActionResult Details(int id)
          {
               GetUserData();

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
               GetUserData();

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
               GetUserData();

               SubscriptionUDbTable data = new SubscriptionUDbTable()
               {
                    Id = subscription.Id,
                    Name = subscription.Name,
                    Description = subscription.Description,
                    Price = subscription.Price,
                    ImageUrl = subscription.ImageUrl

               };

               var subscriptionCreate = _subscription.UpdateSubscription(data);
               if (subscriptionCreate.Status)
               {
                    return RedirectToAction("Index", "Subscription");
               }
               else
               {
                    ModelState.AddModelError("", subscriptionCreate.StatusMsg);
                    return RedirectToAction("Index", "Error");
               }
          }

     }

}