using Microsoft.AspNetCore.Mvc;
using PetAdoption.Models;
using PetAdoption.DataAccess.Data;
using PetAdoption.DataAccess.Repository.IRepository;

namespace PetAdoptionMVC.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepo;
        public AnimalController(IAnimalRepository db) 
        {
            _animalRepo= db;
        }
        public IActionResult Index()
        {
            List<Animal> objAnimalList = _animalRepo.GetAll().ToList();
            return View(objAnimalList);
        }
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal) 
        {
            if(ModelState.IsValid) 
            {
                _animalRepo.Add(animal);
                _animalRepo.Save();
                TempData["success"] = "Animal added successfully";

                return RedirectToAction("Index");
            }
            TempData["error"] = "Error adding animal";
            return View();
   
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            Animal? animalFromDb = _animalRepo.Get(u=>u.Id==id);

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
                _animalRepo.Update(animal);
                _animalRepo.Save();
                TempData["success"] = "Animal updated successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error adding animal";
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }

            Animal? animalFromDb = _animalRepo.Get(u => u.Id == id);

            if (animalFromDb == null) 
            {
                return NotFound();
            }

            return View(animalFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id) 
        {
            Animal? animalFromDb = _animalRepo.Get(u => u.Id == id);

            if(animalFromDb == null) 
            {
                return NotFound();
            }

            _animalRepo.Remove(animalFromDb);
            _animalRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
