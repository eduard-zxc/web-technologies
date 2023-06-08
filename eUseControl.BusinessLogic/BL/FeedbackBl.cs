using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.BL
{
     public class FeedbackBl : FeedbackApi, IFeedback
     {


          public List<FeedbackUDbTable> GetFeedback()
          {
               return GetFeedbackAction();
          }

          public void DeleteFeedback(int id)
          {
               DeleteFeedbackAction(id);
          }
     }

}