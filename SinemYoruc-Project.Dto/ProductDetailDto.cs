using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemYoruc_Project
{
    public class ProductDetailDto
    {
        [Required]
        public bool isOfferable { get; set; }

        [Required]
        public double Offer { get; set; }

        [Required]
        public int ProductId { get; set; }


    }
}
