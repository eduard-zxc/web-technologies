using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface ISubscription
     {
          List<SubscriptionData> GetSubscriptionList();
          PostResponse CreateSubscription(SubscriptionUDbTable subscription);

          PostResponse UpdateSubscription(SubscriptionUDbTable subscription);

          PostResponse DeleteSubscription(int id);

          SubscriptionUDbTable GetSingleSubscription(int id);
     }
}