using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
using eUseControl.Helpers;

namespace eUseControl.BusinessLogic.Core
{
     public class UserApi
     {
          internal PostResponse UserLoginAction(ULoginData data)
          {

               UDbTable result;
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Credential))
               {
                    var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                    }

                    if (result == null)
                    {
                         return new PostResponse { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                    }

                    using (var todo = new UserContext())
                    {
                         result.LasIp = data.LoginIp;
                         result.LastLogin = data.LoginDateTime;
                         todo.Entry(result).State = EntityState.Modified;
                         todo.SaveChanges();
                    }

                    return new PostResponse { Status = true };
               }
               else
               {
                    var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                    }

                    if (result == null)
                    {
                         return new PostResponse { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                    }

                    using (var todo = new UserContext())
                    {
                         result.LasIp = data.LoginIp;
                         result.LastLogin = data.LoginDateTime;
                         todo.Entry(result).State = EntityState.Modified;
                         todo.SaveChanges();
                    }

                    return new PostResponse { Status = true };
               }
          }

          internal PostResponse UserSignupAction(URegisterData data)
          {
               UDbTable result;
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Email))
               {
                    if (data.Password == null || data.Email == null)
                    {
                         return new PostResponse { Status = false, StatusMsg = "Complete all fields" };
                    }

                    if (data.Password != data.ConfirmPassword)
                    {
                         return new PostResponse { Status = false, StatusMsg = "The Passwords don't match" };
                    }

                    if (data.Password.Length < 8)
                    {
                         return new PostResponse { Status = false, StatusMsg = "Password min 8 characters" };
                    }

                    if (data.Username.Length < 5)
                    {
                         return new PostResponse { Status = false, StatusMsg = "Username min 5 characters" };
                    }

                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Email == data.Email);
                    }

                    if (result != null)
                    {
                         return new PostResponse { Status = false, StatusMsg = "The Email is already taken" };
                    }

                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Username == data.Username);
                    }
                    if (result != null)
                    {
                         return new PostResponse { Status = false, StatusMsg = "please use a unique username" };
                    }

                    var pass = LoginHelper.HashGen(data.Password);
                    result = new UDbTable
                    {
                         Username = data.Username,
                         Email = data.Email,
                         Password = pass,
                         LasIp = data.LoginIp,
                         LastLogin = data.LoginDateTime

                    };

                    using (var db = new UserContext())
                    {
                         db.Users.Add(result);
                         db.SaveChanges();

                    }
                    return new PostResponse { Status = true };
               }
               else
               {
                    //empty email is valid for some reason 
                    return new PostResponse { Status = false, StatusMsg = "Invalid email" };

               }
          }
          internal HttpCookie Cookie(string loginCredential)
          {
               var apiCookie = new HttpCookie("X-KEY")
               {
                    Value = CookieGenerator.Create(loginCredential)
               };

               //find email if username used
               UDbTable result;
               using (var db = new UserContext())
               {
                    result = db.Users.FirstOrDefault(u => u.Email == loginCredential || u.Username == loginCredential);
               }

               loginCredential = result.Username;


               using (var db = new UserContext())
               {
                    SessionsDb curent;
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();

                    if (curent != null)
                    {
                         curent.CookieString = apiCookie.Value;
                         curent.ExpireTime = DateTime.Now.AddMinutes(60);
                         using (var up = new UserContext())
                         {
                              up.Entry(curent).State = EntityState.Modified;
                              up.SaveChanges();

                         }
                    }
                    else
                    {
                         db.Sessions.Add(new SessionsDb
                         {
                              Username = loginCredential,
                              CookieString = apiCookie.Value,
                              ExpireTime = DateTime.Now.AddMinutes(60)
                         });
                         db.SaveChanges();
                    }
               }
               return apiCookie;
          }
          [Obsolete]
          internal UserMinimal UserCookie(string cookie)
          { 
               SessionsDb session;
            UDbTable curentUser;

            using (var db = new UserContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            var userprofile = new UserMinimal
            {
                Id = curentUser.Id,
                Username = curentUser.Username,
                Email = curentUser.Email,
                Level = curentUser.Level
            };

            return userprofile;
          }
     }
}