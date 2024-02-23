using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace PetAdoption.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [DisplayName("Product Name")]
        public required string Name { get; set; }

        public required string Type { get; set; }

        public required string Description { get; set; }

        [DisplayName("Available Quantity")]
        [Range(1,1000)]
        public required int availableQuantity { get; set; }
    }
}
