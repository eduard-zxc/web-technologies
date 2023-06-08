using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Domain.Entities.Subscription
{
     public class SubscriptionUDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          [Display(Name = "Name")]
          public string Name { get; set; }

          [Required]
          [Display(Name = "Price Per Month")]
          public int Price { get; set; }

          [Required]
          [Display(Name = "Description")]
          public string Description { get; set; }

          [Required]
          [Display(Name = "ImageUrl")]
          public string ImageUrl { get; set; }
     }
}