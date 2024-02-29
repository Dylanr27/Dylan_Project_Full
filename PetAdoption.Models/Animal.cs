using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetAdoption.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        [Range(0, 30, ErrorMessage = "Age must be between 0-30")]
        public int? Age { get; set; }

        public required string Species { get; set; }

        public string? Breed { get; set; }

        public string? Sex { get; set; }

        public string? Size { get; set; }

        public string? Description { get; set; }

        [DisplayName("Photo Url")]
        public string? PhotoUrl { get; set; }

        public static bool modelProvided(Animal animal)
        {
            if (animal is not null && animal.Id != 0)
            {
                return true;
            }
            return false;
        }
    }
}
