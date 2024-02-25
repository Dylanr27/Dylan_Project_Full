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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.animal.Add(animal);
                _unitOfWork.Save();
                TempData["success"] = "Animal added successfully";

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

        public IActionResult Edit(int? id)
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

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.animal.Update(animal);
                _unitOfWork.Save();
                TempData["success"] = "Animal updated successfully";
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
