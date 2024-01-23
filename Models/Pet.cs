using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMVC.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int age { get; set; }
        [Required]
        public string species { get; set; }
        public string breed { get; set; }
        public string gender { get; set; }
        public string size { get; set; }
        public string description { get; set; }
        public string AdoptionStatus { get; set; }
    }
}
