using System;
using System.Data.Entity;
using System.Linq;
using eUseControl.BusinessLogic.BL;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Order;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Core
{
     public class OrderApi
     {
          internal PostResponse CreateOrderAction(OrderDbTable order)
          {
               if (order != null)
               {
                    return new PostResponse { Status = false, StatusMsg = "Data is Invalid" };
               }

               order = AddOrderDetails(order);

               using (var db = new UserContext())

               {
                    db.Orders.Add(order);
                    db.SaveChanges();
               }
               return new PostResponse { Status = true };
          }

          private OrderDbTable AddOrderDetails(OrderDbTable order)
          {
               var bl = new BussinesLogic();
               var subscriptionDuration = bl.GetsSubscriptionDurationBl();
               var subscription = bl.GetSubscriptionBl();
               var subs = subscription.GetSingleSubscription(order.SubscriptionId);
               var subsDetails = subscriptionDuration.GetSingleSubscriptionDuration(order.SubscriptionDurationId);
               var trainer = bl.GetTrainerBl();
               var trainerPrice = 0;
               if (order.TrainerId != null)
               {
                    var trainerDetails = trainer.GetSingleTrainer(order.TrainerId);
                    trainerPrice = trainerDetails.Price;
               }

               order.Price = subs.Price * subsDetails.Months +trainerPrice*subsDetails.Months;
               order.Price -= order.Price*(subsDetails.Discount/100);
               order.ExpirationDate = order.PurchaseDate.AddMonths(subsDetails.Months);
               return order;
          }

          internal OrderDbTable GetOrderByTrainerIdAction(int trainerId)
          {
               using (var db = new UserContext())
               {
                    return db.Orders.FirstOrDefault(item => item.TrainerId == trainerId);
               }
          }

          internal OrderDbTable GetOrderByUserIdAction(int userId)
          {
               using (var db = new UserContext())
               {
                    return db.Orders.FirstOrDefault(item => item.TrainerId == userId);
               }
          }

          internal void CheckExpirationAction()
          {
               using (var db = new UserContext())
               {
                    var orders = db.Orders.ToList();
                    foreach (var item in orders)
                    {
                         if (item.ExpirationDate >= DateTime.Now)
                         {
                              item.IsValid = false;
                         }

                         db.Entry(item).State = EntityState.Modified;
                         db.SaveChanges();
                    }
               }
          }
     }
}
