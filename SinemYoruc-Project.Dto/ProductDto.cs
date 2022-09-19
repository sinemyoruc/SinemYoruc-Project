using SinemYoruc_Project.Data;
using System.ComponentModel.DataAnnotations;

namespace SinemYoruc_Project.Dto
{
    public class ProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool isOfferable { get; set; }
        public bool isSold { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public double Price { get; set; }

        public Category Category { get; set; }
        public ProductsOffer ProductsOffer { get; set; }

        public int AccountId { get; set; }
    }
}
