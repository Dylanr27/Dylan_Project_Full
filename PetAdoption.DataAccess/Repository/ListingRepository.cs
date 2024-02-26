using PetAdoption.DataAccess.Data;
using PetAdoption.DataAccess.Repository.IRepository;
using PetAdoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.DataAccess.Repository
{
    public class ListingRepository : Repository<Listing>, IListingRepository
    {
        private ApplicationDbContext _db;
        public ListingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Listing obj)
        {
            _db.Listing.Update(obj);
        }
    }
}
