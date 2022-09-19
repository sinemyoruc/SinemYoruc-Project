using System.ComponentModel.DataAnnotations;

namespace SinemYoruc_Project
{
    public class ProductsOfferDto
    {
        [Required]
        public bool isOfferable { get; set; }

        [Required]
        public double Offer { get; set; }

        [Required]
        public int ProductId { get; set; }
        public int OfferAccountId { get; set; }
        public bool OfferStatus { get; set; }

    }
}
