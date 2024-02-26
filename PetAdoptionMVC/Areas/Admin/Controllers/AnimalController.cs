using Microsoft.AspNetCore.Mvc;
using PetAdoption.Models;
using PetAdoption.DataAccess.Data;
using PetAdoption.DataAccess.Repository.IRepository;

namespace PetAdoptionMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnimalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnimalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Animal> objAnimalList = _unitOfWork.animal.GetAll().ToList();
            return View(objAnimalList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                Animal objAnimal = _unitOfWork.animal.Get(u => u.Id == id);
                return View(objAnimal);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.Id == 0)
                {
                    _unitOfWork.animal.Add(animal);
                    _unitOfWork.Save();
                    TempData["success"] = "Animal added successfully";
                }
                else

                {
                    _unitOfWork.animal.Update(animal);
                    _unitOfWork.Save();
                    TempData["success"] = "Animal updated successfully";
                }

                return RedirectToAction("Index");
            }

            var errors = ModelState.Values.SelectMany(x => x.Errors);

            foreach (var error in errors)
            {
                TempData["error"] = error.ErrorMessage;
                break;
            }

            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Animal? animalFromDb = _unitOfWork.animal.Get(u => u.Id == id);

            if (animalFromDb == null)
            {
                return NotFound();
            }

            return View(animalFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            Animal? animalFromDb = _unitOfWork.animal.Get(u => u.Id == id);

            if (animalFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.animal.Remove(animalFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Animal removed successfully";
            return RedirectToAction("Index");
        }

    }
}
