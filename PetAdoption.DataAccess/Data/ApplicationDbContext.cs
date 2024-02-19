using Microsoft.EntityFrameworkCore;
using PetAdoption.Models;


namespace PetAdoption.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
            
        }

        public DbSet<Animal> Animal {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new Animal {  
                    Id = 1,
                    Name = "Gizmo", 
                    Age = 7,
                    Species = "Cat",
                    Breed = "Russian Blue",
                    Sex = "Male",
                    Size = "M",
                    Description = "Rescue",
                    AdoptionStatus = "Available",
                    PhotoUrl = "/lib/Images/pexels-monica-oprea-9718154.jpg"
                }
            );
        }
    }
}
      