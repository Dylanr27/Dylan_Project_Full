using PetAdoption.Models;

namespace PetAdoption.DataAccess.Repository.IRepository
{
    public interface IListingRepository : IRepository<Listing>
    {
        void Update(Listing obj);
    }
}
