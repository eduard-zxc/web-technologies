using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Feedback;

namespace eUseControl.BusinessLogic.Core
{
     public class FeedbackApi
     {
          public List<FeedbackUDbTable> GetFeedbackAction()
          {
               using (var dbContext = new UserContext())
               {
                    return dbContext.Feedback.ToList();
               }
          }

          public void DeleteFeedbackAction(int id)
          {
               using (var dbContext = new UserContext())
               {
                    var feedback = dbContext.Feedback.Find(id);
                    if (feedback != null)
                    {
                         dbContext.Feedback.Remove(feedback);
                         dbContext.SaveChanges();
                    }
               }
          }

          public void SaveFeedback(FeedbackUDbTable feedback)
          {
               using (var dbContext = new UserContext())
               {
                    dbContext.Feedback.Add(feedback);
                    dbContext.SaveChanges();
               }
          }
     }
}