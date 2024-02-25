using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PetAdoption.Utility;


namespace PetAdoption.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [DisplayName("Product Brand")]
        public required string Brand { get; set; }

        public required string Type { get; set; }

        [EndsWith(".")]
        public required string Description { get; set; }

        [DisplayName("Available Quantity")]
        [Range(1,1000)]
        public required int AvailableQuantity { get; set; }

        public string? PhotoUrl { get; set; }
    }
}
