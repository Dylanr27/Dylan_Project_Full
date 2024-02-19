using PetAdoption.DataAccess.Repository.IRepository;
using PetAdoption.DataAccess.Data;
using PetAdoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.DataAccess.Repository
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        private ApplicationDbContext _db;
        public AnimalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Animal obj)
        {
            _db.Animal.Update(obj);
        }
    }
}
