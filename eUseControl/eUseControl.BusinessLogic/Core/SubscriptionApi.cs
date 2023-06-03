using eUseControl.Domain.Entities.User;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Subscription;

namespace eUseControl.BusinessLogic.Core
{
    public class SubscriptionApi
    {
        internal PostResponse CreateSubscriptionAction(SubscriptionUDbTable subscription)
        {
            if (string.IsNullOrEmpty(subscription.Name))
            {
                return new PostResponse { Status = false, StatusMsg = "Add Subscription Name" };
            }

            if (string.IsNullOrEmpty(subscription.Description))
            {
                return new PostResponse { Status = false, StatusMsg = "Add Subscrpition Description" };
            }

            if (string.IsNullOrEmpty(subscription.ImageUrl))
            {
                return new PostResponse { Status = false, StatusMsg = "Add Subscrpition Description" };
            }

            using (var db = new UserContext())
            {

                //adaug 
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
            }

            return new PostResponse { Status = true };
        }

        internal List<SubscriptionData> GetSubscriptionListAction()
        {
            List<SubscriptionData> subscriptions = new List<SubscriptionData>();
            using (var db = new UserContext())
            {
                var result = db.Subscriptions.ToList();

                for (int i = 0; i < result.Count; i++)
                {
                    subscriptions.Add(new SubscriptionData
                    {
                        Id = result[i].Id,
                        Name = result[i].Name,
                        Description = result[i].Description,
                        Price = result[i].Price,
                        ImageUrl = result[i].ImageUrl
                    });
                }
            }

            return subscriptions;
        }

        internal SubscriptionUDbTable GetSingleSubscriptionAction(int id)
        {
            using (var db = new UserContext())
            {
                return db.Subscriptions.FirstOrDefault(p => p.Id == id);
            }
        }

        internal PostResponse EditSubscriptionAction(SubscriptionUDbTable subscription)
        {
            using (var db = new UserContext())
            {
                var tableSubscription = db.Subscriptions.FirstOrDefault(p => p.Id == subscription.Id);
                if (tableSubscription == null)
                {
                    return new PostResponse { Status = false, StatusMsg = "no such item id" };
                }

                if (subscription.Name != null && subscription.Name != tableSubscription.Name)
                {
                    tableSubscription.Name = subscription.Name;
                }

                if (subscription.Description != null && subscription.Description != tableSubscription.Description)
                {
                    tableSubscription.Description = subscription.Description;
                }

                if (subscription.Price != 0 && subscription.Price != tableSubscription.Price)
                {
                    tableSubscription.Price = subscription.Price;
                }

                if (subscription.ImageUrl != null && subscription.ImageUrl != tableSubscription.ImageUrl)
                {
                    tableSubscription.ImageUrl = subscription.ImageUrl;
                }

                db.Entry(tableSubscription).State = EntityState.Modified;
                db.SaveChanges();
            }

            return new PostResponse { Status = true };
        }

        internal PostResponse DeleteSubscriptionByIdAction(int id)
        {
            using (var db = new UserContext())
            {
                var result = db.Subscriptions.FirstOrDefault(p => p.Id == id);
                if (result != null)
                {
                    db.Subscriptions.Remove(result);
                    db.SaveChanges();
                    return new PostResponse { Status = true, StatusMsg = "Deleted Subscription " };
                }
                else
                {
                    return new PostResponse { Status = false, StatusMsg = "Couldn't delete, no such id" };
                }
            }

        }
    }
}
