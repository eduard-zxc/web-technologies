using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Order;
using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.Trainer;
using eUseControl.Web;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
     public class OrderController : BaseController
     {
          private readonly ISubscription _subscription;
          private readonly ITrainer _trainers;
          private readonly ISubscriptionDuration _details;
          private readonly IOrder _order;
          public OrderController()
          {
               var bl = new BussinesLogic();
               _subscription = bl.GetSubscriptionBl();
               _trainers = bl.GetTrainerBl();
               _details =bl.GetsSubscriptionDurationBl();
               _order = bl.GetOrderBl();
          }
          public ActionResult Index()
          {
               GetUserData();

               var subscriptions = _subscription.GetSubscriptionList();
               var trainers = _trainers.GetTrainersList();
               var details = _details.GetAllSubscriptionDuration();
               OrderModel data = new OrderModel();
               foreach (var item in subscriptions)
                    data.OrderData.Subscriptions.Add(new SubscriptionData
                    {
                         Id = item.Id,
                         Name = item.Name,
                         Description = item.Description,
                         Price = item.Price,
                         ImageUrl = item.ImageUrl
                    });
               foreach (var item in trainers)
                    data.OrderData.Trainers.Add(new Trainer
                    {
                         Id = item.Id,
                         Name = item.Name,
                         ImageUrl = item.ImageUrl,
                         Age = item.Age,
                         Bio = item.Bio,
                         Number = item.Number,
                         Specialization = item.Specialization,
                         Availability = item.Availability,
                         Price = item.Price
                    });
               foreach (var item in details)
                    data.OrderData.SubscriptionDurations.Add(new SubscriptionDuration()
                    {

                         Id = item.Id,
                         Name = item.Name,
                         Months = item.Months,
                         Discount = item.Discount
                    });

               return View(data);

          }


          [HttpPost]
          public ActionResult Index(OrderModel order)
          {
               GetUserId();
               var data = new OrderDbTable()
               {
                    UserId = ViewBag.UserId,
                    SubscriptionId = order.Orders.SubscriptionId,
                    TrainerId = order.Orders.TrainerId,
                    SubscriptionDurationId = order.Orders.SubscriptionDurationId,
                    PurchaseDate = DateTime.Now,
                    IsValid = true

               };
               _order.CreateOrder(data);
               return RedirectToAction("Index", "Subscription");
          }
     }
}