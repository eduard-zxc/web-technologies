using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class Feedback
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 20)]
        public string Subject { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 30)]
        public string Message { get; set; }

    }
}