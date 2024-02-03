using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using System.Reflection.Metadata.Ecma335;

namespace PetAdoptionMVC.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AnimalController(ApplicationDbContext db) 
        {
            _db= db;
        }
        public IActionResult Index()
        {
            List<Animal> objAnimalList = _db.Animal.ToList();
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
                _db.Animal.Add(animal);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
   
        }

        public IActionResult Edit(int? id)
        {
            Console.WriteLine("Selected animals id: " + id);
            if (id == null || id == 0) 
            {
                Console.WriteLine("Selected animals id: " + id);
                return NotFound();
            }
            Animal? animalFromDb = _db.Animal.Find(id);

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
                _db.Animal.Update(animal);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Delete(int? id) 
        //{
          //  return View(animal);
        //}
        
    }
}
