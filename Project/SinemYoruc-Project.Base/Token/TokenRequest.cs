using System.ComponentModel.DataAnnotations;

namespace SinemYoruc_Project.Base
{
    public class TokenRequest
    {
        [Required]
        [MaxLength(125)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
