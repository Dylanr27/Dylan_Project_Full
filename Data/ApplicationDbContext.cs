using Microsoft.EntityFrameworkCore;

namespace PetAdoptionMVC.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
            {
            
            }
    }
}
      