using PetAdoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.DataAccess.Repository.IRepository
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        void Update(Animal obj);
        void Save();

    }
}
