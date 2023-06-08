using System;
using eUseControl.Domain.Enums;

namespace eUseControl.Web.Models
{
    public class UserData
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime LastLogin { get; set; }

        public string LasIp { get; set; }

        public URole Level { get; set; }

        public int? TrainerId { get; set; }
    }
}