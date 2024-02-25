using PetAdoption.DataAccess.Repository.IRepository;
using PetAdoption.DataAccess.Data;
using PetAdoption.Models;

namespace PetAdoption.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Product.Update(obj);
        }
    }
}
