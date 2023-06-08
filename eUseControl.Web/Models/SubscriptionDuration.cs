using System;

namespace eUseControl.Web.Models
{
     public class SubscriptionDuration
     {
          public int Id { get; set; }

          public string Name { get; set; }

          public int Months { get; set; }

          public int Discount { get; set; }
     }
}