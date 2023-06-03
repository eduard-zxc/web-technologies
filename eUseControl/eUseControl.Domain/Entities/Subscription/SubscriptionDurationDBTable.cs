using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entities.Subscription
{
     public class SubscriptionDurationDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public string Name { get; set; }

          [Required]
          public int Duration { get; set; }

          [Required]
          public int Price { get; set; }
     }
}
