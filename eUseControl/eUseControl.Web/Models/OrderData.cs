using eUseControl.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities.Subscription;

namespace eUseControl.Web.Models
{
     public class OrderData
     {
          public List<SubscriptionData> Subscriptions { get; set; }
          public List <Trainer> Trainers { get; set; }
          public List<SubscriptionDuration> SubscriptionDurations { get; set; }

          public OrderData()
          {
               Subscriptions = new List<SubscriptionData>();
               Trainers = new List<Trainer>();
               SubscriptionDurations = new List<SubscriptionDuration>();
          }
     }
}