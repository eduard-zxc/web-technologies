using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
         PostResponse UserRegister(URegisterData data);
         PostResponse UserLogin(ULoginData data);
         string GenUserCookie(ULoginData data);
         HttpCookie GenCookie(string loginCredential);
        UserMinimal GetUserByCookie(string apiCookieValue);
    }
}
