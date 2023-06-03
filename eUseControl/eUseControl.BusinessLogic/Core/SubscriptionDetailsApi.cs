using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.User;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using eUseControl.BusinessLogic.DBModel;

namespace eUseControl.BusinessLogic.Core
{
    public class SubscripitionDetailsApi
    {
        internal PostResponse CreateSubscriptionDurationAction(SubscriptionDurationDbTable subscription)
        {
            using (var db = new UserContext())
            {
                db.SubscriptionsDuration.Add(subscription);
                db.SaveChanges();
            }
            return new PostResponse { Status = true };
        }
        internal List<SubscriptionDurationData> GetAllSubscriptionDurationAction()
        {
            using (var db = new UserContext())
            {
                var subscription = new List<SubscriptionDurationData>();

                var result = db.SubscriptionsDuration.ToList();
                foreach (var data in result)
                {
                    subscription.Add(new SubscriptionDurationData
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Duration = data.Duration,
                        Price = data.Price
                    }
                    );
                }
                return subscription;
            }
        }

        internal PostResponse DeleteSubscriptionDurationAction(int id)
        {
            using (var db = new UserContext())
            {
                var result = db.SubscriptionsDuration.FirstOrDefault(i => i.Id == id);
                if (result == null)
                {
                    return new PostResponse { Status = true, StatusMsg = "Deleted row: " };
                }
                else
                {
                    return new PostResponse { Status = false, StatusMsg = "Couldn't delete, no such id" };
                }
            }
        }

    }
}
