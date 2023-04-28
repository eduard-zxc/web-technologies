using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
          [Display(Name = "Price")]
          public string Price { get; set; }

          [Required]
          [Display(Name = "Duration")]
          public string Duration { get; set; }
     }
}
