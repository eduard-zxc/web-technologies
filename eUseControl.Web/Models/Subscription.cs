﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace eUseControl.Web.Models
{
     public class Subscription
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public int Price { get; set; }

          public string ImageUrl{ get; set; }
     }
}