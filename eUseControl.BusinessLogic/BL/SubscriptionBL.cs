using System.Collections.Generic;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.BL
{
     public class SubscriptionBl : SubscriptionApi, ISubscription
     {
          public List<SubscriptionData> GetSubscriptionList()
          {
               return GetSubscriptionListAction();
          }

          public PostResponse CreateSubscription(SubscriptionUDbTable subscription)
          {
               return CreateSubscriptionAction(subscription);
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