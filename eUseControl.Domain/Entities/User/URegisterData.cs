using eUseControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eUseControl.Domain.Entities.User
{
     public class URegisterData
     {
          public string Username { get; set; }
          public string Password { get; set; }
          public string ConfirmPassword { get; set; }
          public string Email { get; set; }
          public URole Level { get; set; }
          public string LoginIp { get; set; }
          public DateTime LoginDateTime { get; set; }
          public int? TrainerId { get; set; }

     }
}