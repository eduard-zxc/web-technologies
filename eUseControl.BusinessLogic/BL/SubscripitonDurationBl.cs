using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Subscription;
using eUseControl.Domain.Entities.SubscriptionDuration;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.BL
{
     internal class SubscriptionDurationBl : SubscriptionDurationApi, ISubscriptionDuration
     {
          public List<SubscriptionDurationData> GetAllSubscriptionDuration()
          {
               return GetAllSubscriptionDurationAction();
          }

          public PostResponse DeleteSubscriptionDuration(int id)
          {
               return DeleteSubscriptionDurationAction(id);
          }

          public PostResponse AddSubscriptionDuration(SubscriptionDurationDbTable subscription)
          {
               return CreateSubscriptionDurationAction(subscription);
          }
          public SubscriptionDurationDbTable GetSingleSubscriptionDuration(int id)
          {
               return GetSingleSubscriptionDurationAction(id);
          }
     }
}