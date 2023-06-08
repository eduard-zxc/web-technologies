using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Domain.Entities.Feedback
{
     public class FeedbackUDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public string Email { get; set; }
          public string Subject { get; set; }
          public string Message { get; set; }
          public DateTime Time { get; set; }
     }
}