using System;
using System.Web;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Helpers.Session;

namespace eUseControl.BusinessLogic.BL
{
     public class SessionBl : UserApi, ISession
     {


          public PostResponse UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }
          public PostResponse UserRegister(URegisterData data)
          {
               return UserSignupAction(data);
          }

          public string GenUserCookie(ULoginData data)
          {
               var session = new SessionActionType();
               var cookie = session.GenerateCookieBase(data.Credential);

               return cookie;
          }
          public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }
          [Obsolete]
          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }

          public int? GetIdTrainer(int id)
          {
               return GetIdTrainerAction(id);
          }
     }
}