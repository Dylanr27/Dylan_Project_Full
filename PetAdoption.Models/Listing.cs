using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }

        public int? AnimalId { get; set; }
        [ForeignKey("AnimalId")]
        [ValidateNever]
        public Animal Animal { get; set; }
    }
}
