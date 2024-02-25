using PetAdoption.DataAccess.Repository.IRepository;
using PetAdoption.DataAccess.Data;
using PetAdoption.Models;

namespace PetAdoption.DataAccess.Repository
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        private ApplicationDbContext _db;
        public AnimalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Animal obj)
        {
            _db.Animal.Update(obj);
        }
    }
}
