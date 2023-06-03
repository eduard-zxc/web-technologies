using System;
using System.Linq;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Order;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Core
{
    public class OrderApi
    {
        internal PostResponse CreateOrderAction(OrderDbTable order)
        {

            if (order is null)
            {
                return new PostResponse { Status = false, StatusMsg = "Data is Invalid" };
            }

            using (var db = new UserContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
            return new PostResponse { Status = true };
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
                }
                db.SaveChanges();
            }
        }
    }
}
