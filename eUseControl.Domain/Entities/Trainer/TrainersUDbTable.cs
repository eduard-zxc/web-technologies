using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Domain.Entities.Trainer
{
     public class TrainersUDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Display(Name = "Name")]
          public string Name { get; set; }

          [Display(Name = "ImageUrl")]
          public string ImageUrl { get; set; }

          [Display(Name = "Age")]
          public int Age { get; set; }

          [Display(Name = "Bio")]
          public string Bio { get; set; }

          [Display(Name = "Contact Number")]
          public int Number { get; set; }

          [Display(Name = "Specialization")]
          public string Specialization { get; set; }

          [Display(Name = "Availability")]
          public string Availability { get; set; }

          [Display(Name = "Price")]
          public int Price { get; set; }

     }
}