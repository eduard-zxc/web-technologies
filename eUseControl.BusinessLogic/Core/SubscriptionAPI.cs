using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Subscription;

namespace eUseControl.BusinessLogic.Core
{
     public class SubscriptionAPI
     {


          internal PostResponse CreateSubscriptiontAction(SubscriptionUDbTable subscription)
          {
               if (subscription.Name == null || subscription.Name.Length == 0)
               {
                    return new PostResponse { Status = false, StatusMsg = "Add Subscription Name" };
               }

               if (subscription.Description == null || subscription.Description.Length == 0)
               {
                    return new PostResponse { Status = false, StatusMsg = "Add Subscrpition Description" };
               }

               using (var db = new UserContext())
               {
                    //find max id
                    var subscriptionID = db.Subscriptions
                         .OrderBy(f => f.Id)
                         .ToList();
                    //adaug 
                    db.Subscriptions.Add(subscription);
                    db.SaveChanges();
               }

               return new PostResponse { Status = true };
          }
          internal List<SubscriptionData> GetSubscriptionListAction()
          {
          List<SubscriptionData> SubscriptionData = new List<SubscriptionData>();
               using (var db = new UserContext())
               {
                    var result = db.Subscriptions
                        .OrderBy(f => f.Id)
                        .ToList();

                    for (int i = 0; i < result.Count; i++)
                    {
                         SubscriptionData.Add(new SubscriptionData
                         {
                              Id = result[i].Id,
                              Name = result[i].Name,
                              Description = result[i].Description,
                         });
                    }
               }
               return SubscriptionData;
          }

          internal SubscriptionUDbTable GetSingleSubscriptionAction(int id)
          {
               using (var db = new UserContext())
               {
                    return db.Subscriptions.FirstOrDefault(p => p.Id == id);
               }
          }
          internal PostResponse EditSubscriptionAction(SubscriptionUDbTable product)
          {
               using (var db = new UserContext())
               {
                    var tableProduct = db.Subscriptions.FirstOrDefault(p => p.Id == product.Id);
                    if (tableProduct == null)
                    {
                         return new PostResponse { Status = false, StatusMsg = "no such item id" };
                    }
                    if (product.Name != null && product.Name != tableProduct.Name)
                    {
                         tableProduct.Name = product.Name;
                    }

                    if (product.Description != null && product.Description != tableProduct.Description)
                    {
                         tableProduct.Description = product.Description;
                    }

                    if (product.Price != null && product.Price != tableProduct.Price)
                    {
                         tableProduct.Price = product.Price;
                    }
                    db.Entry(tableProduct).State = EntityState.Modified;
                    db.SaveChanges();
               }
               return new PostResponse { Status = true };
          }
          internal PostResponse DeleteSubscriptionByIdAction(int id)
          {
               using (var db = new UserContext())
               {
                    var result = db.Subscriptions.FirstOrDefault(p => p.Id == id);
                    if (result != null)
                    {
                         db.Subscriptions.Remove(result);
                         db.SaveChanges();
                         return new PostResponse { Status = true, StatusMsg = "Deleted row: "};
                    }
                    else
                    {
                         return new PostResponse { Status = false, StatusMsg = "Couldn't delete, no such id" };
                    }
               }

          }


     }
}
