using System.ComponentModel.DataAnnotations;

namespace SinemYoruc_Project
{
    public class ProductsOfferDto
    {

        [Required]
        public double Offer { get; set; }

        [Required]
        public int ProductId { get; set; }
        public int OfferAccountId { get; set; }
    }
}
