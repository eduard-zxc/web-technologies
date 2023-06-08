using eUseControl.Domain.Entities.Feedback;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IFeedback
     {
          List<FeedbackUDbTable> GetFeedback();
          void DeleteFeedback(int id);
          void SaveFeedback(FeedbackUDbTable feedback);
     }
}