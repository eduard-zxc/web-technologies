using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.Subscription
{
     public class SubscriptionDurationData
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public int Months { get; set; }

          public int Discount { get; set; }
     }
}