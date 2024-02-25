using PetAdoption.Models;

namespace PetAdoption.DataAccess.Repository.IRepository
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        void Update(Animal obj);

    }
}
