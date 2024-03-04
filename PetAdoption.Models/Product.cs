using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PetAdoption.Utility;


namespace PetAdoption.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Product Brand")]
        public string Brand { get; set; }

        [Required]
        public string Type { get; set; }

        //[EndsWith(".")]
        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Available Quantity")]
        [Range(1,1000)]
        public int AvailableQuantity { get; set; }

        public string? PhotoUrl { get; set; }

        public static bool modelProvided(Product product)
        {
            if (product is not null && product.Id != 0)
            {
                return true;
            }
            return false;
        }
    }
}
