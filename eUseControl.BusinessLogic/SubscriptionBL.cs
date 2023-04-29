using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic
{
     public class SubscriptionBL :SubscriptionAPI , ISubscription
     {
          public List<SubscriptionData> GetSubscriptionList()
          {
               return GetSubscriptionListAction();
          }

          public PostResponse CreateSubscription(SubscriptionUDbTable subscription)
          {
               return CreateSubscriptiontAction(subscription);
          }

          public PostResponse UpdateSubscription(SubscriptionUDbTable subscription)
          {
               return EditSubscriptionAction(subscription);
          }

          public PostResponse DeleteSubscription(int id)
          {
               return DeleteSubscriptionByIdAction(id);
          }

          public SubscriptionUDbTable GetSingleSubscription(int id)
          {
               return GetSingleSubscriptionAction(id);
          }
     }
}
