using PetAdoption.DataAccess.Data;
using PetAdoption.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IAnimalRepository animal { get; private set; }

        public IProductRepository product { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            animal = new AnimalRepository(_db);
            product = new ProductRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
