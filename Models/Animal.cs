using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMVC.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Age { get; set; }
        [Required]
        public string? Species { get; set; }
        public string? Breed { get; set; }
        public string? Sex { get; set; }
        public string? Size { get; set; }
        public string? Description { get; set; }
        [Required]
        public string AdoptionStatus { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
