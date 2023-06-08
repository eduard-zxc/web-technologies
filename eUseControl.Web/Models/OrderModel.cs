using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
     public class OrderModel
     {
          public Order Orders { get; set; }
          public OrderData OrderData { get; set; }


          public OrderModel()
          {
               OrderData = new OrderData();
               Orders = new Order();

          }
     }
}