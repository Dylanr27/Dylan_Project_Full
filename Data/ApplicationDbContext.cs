using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Models;


namespace PetAdoptionMVC.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
            
        }

        public DbSet<Animal> Animal {  get; set; } 
    }
}
      