using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class UserLogin
    {
        public string Credential { get; set; }
        public string Password { get; set; }
    }
}