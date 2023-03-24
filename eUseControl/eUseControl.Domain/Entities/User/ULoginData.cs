using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
    public class ULoginData
    {
        public string Credential { get; set; }
        public string Password { get; set; }
        public string LoginIp{ get; set; }
        public string LoginDateTime { get; set; }

        public static implicit operator ULoginData(ULoginData v)
        {
            throw new NotImplementedException();
        }
    }
}
