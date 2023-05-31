using System.Collections.Generic;
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
