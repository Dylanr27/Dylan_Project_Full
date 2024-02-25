using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAnimalRepository animal { get; }

        IProductRepository product { get; }

        void Save();
    }
}
