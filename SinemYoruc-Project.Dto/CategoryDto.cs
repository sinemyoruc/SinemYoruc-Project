using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemYoruc_Project.Dto
{
    public class CategoryDto
    {
        [Required]
        [MaxLength(500)]
        public virtual string CategoryName { get; set; }
    }
}
