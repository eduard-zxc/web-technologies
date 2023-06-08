using System;

namespace eUseControl.Domain.Entities.Feedback
{
     public class FeedbackModel
     {
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public string Email { get; set; }
          public string Subject { get; set; }
          public string Message { get; set; }
          public DateTime Time { get; set; }
     }
}