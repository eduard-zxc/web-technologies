using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entities.SubscriptionDuration
{
     public class SubscriptionDurationDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          [Display(Name = "Subscription Name")]
          public string Name { get; set; }
          [Display(Name = "Months")]
          [Required]
          public int Months { get; set; }

          [Required]
          [Range(1, 100, ErrorMessage = "Discount must be between 1 and 100.")]
          public int Discount { get; set; }
     }
}