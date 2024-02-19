using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetAdoption.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 30, ErrorMessage = "Age must be between 0-30")]
        public int? Age { get; set; }

        [Required]
        public string? Species { get; set; }

        public string? Breed { get; set; }

        public string? Sex { get; set; }

        public string? Size { get; set; }

        public string? Description { get; set; }

        [Required]
        [DisplayName("Adoption Status")]
        public string AdoptionStatus { get; set; }

        [DisplayName("Photo Url")]
        public string? PhotoUrl { get; set; }
    }
}
