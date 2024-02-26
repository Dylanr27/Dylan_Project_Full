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
        public DbSet<Product> Product {  get; set; }
        public DbSet<Listing> Listing {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new Animal 
                {
                    Id = 1,
                    Name = "Gizmo",
                    Age = 7,
                    Species = "Cat",
                    Breed = "Russian Blue",
                    Sex = "Male",
                    Size = "M",
                    Description = "Rescue",
                    PhotoUrl = "/lib/Images/pexels-monica-oprea-9718154.jpg"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Brand = "Wild Coast",
                    Type = "Cat Food",
                    Description = "Raw pork cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.",
                    AvailableQuantity = 50,
                    PhotoUrl="/lib/Images/wild-coast-raw-pork.png"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2,
                    Brand = "Wild Coast",
                    Type = "Cat Food",
                    Description = "Raw chicken cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.",
                    AvailableQuantity = 65,
                    PhotoUrl="/lib/Images/wild-coast-raw-chicken.jpg"
                });
            
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 3,
                    Brand = "Wild Coast",
                    Type = "Cat Food",
                    Description = "Raw beef cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.",
                    AvailableQuantity = 45,
                    PhotoUrl="/lib/Images/wild-coast-raw-beef.jpg"
                });
            
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 4,
                    Brand = "Wild Coast",
                    Type = "Cat Food",
                    Description = "Raw turkey cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.",
                    AvailableQuantity = 30,
                    PhotoUrl="/lib/Images/wild-coast-raw-turkey.jpg"
                });

            modelBuilder.Entity<Listing>().HasData(
                new Listing
                {
                    Id = 1,
                    Price = 100.00m,
                    ProductId = null,
                    AnimalId = 1,
                });
            
        }
    }
}
      