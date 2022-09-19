using SinemYoruc_Project.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SinemYoruc_Project.Dto
{
    public class AccountDto
    {
        [Required]
        [MaxLength(500)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(500)]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        [MaxLength(500)]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }
        

        [RoleAttribute]
        public string Role { get; set; }


        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
    }
}
