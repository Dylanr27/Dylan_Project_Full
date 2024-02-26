using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Models
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }

        public required decimal Price { get; set; }

        public int? productId { get; set; }

        public int? animalId { get; set; }
    }
}
