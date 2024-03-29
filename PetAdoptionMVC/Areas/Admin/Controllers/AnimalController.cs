﻿using Microsoft.AspNetCore.Mvc;
using PetAdoption.Models;
using PetAdoption.DataAccess.Data;
using PetAdoption.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using PetAdoption.Utility;

namespace PetAdoptionMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AnimalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AnimalController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;

            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Upsert(Animal animal, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    string animalPath = Path.Combine(wwwRootPath, @"Images\Animals");

                    if (!string.IsNullOrEmpty(animal.PhotoUrl))
                    {
                        var oldPhotoPath = Path.Combine(wwwRootPath, animal.PhotoUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldPhotoPath))
                        {
                            System.IO.File.Delete(oldPhotoPath);
                        }
                    }

                    using (var fileStream = new FileStream(
                        Path.Combine(animalPath, fileName),
                        FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    animal.PhotoUrl = @"/Images/Animals/" + fileName;
                }
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

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Animal> objAnimalList = _unitOfWork.animal.GetAll().ToList();
            return Json(new { data = objAnimalList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Animal? animalToBeDeleted = _unitOfWork.animal.Get(u => u.Id == id);
            Listing? listingFromDb = _unitOfWork.listing.Get(u => u.AnimalId == id);

            if (animalToBeDeleted is null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            if (animalToBeDeleted.PhotoUrl is not null)
            {
                var oldPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, animalToBeDeleted.PhotoUrl.TrimStart('/'));

                if (System.IO.File.Exists(oldPhotoPath))
                {
                    System.IO.File.Delete(oldPhotoPath);
                }
            }

            _unitOfWork.animal.Remove(animalToBeDeleted);

            if (listingFromDb is not null)
            {
                _unitOfWork.listing.Remove(listingFromDb);
            };

            _unitOfWork.Save();

            return Json(new { success = true, message = "Animal removed successfully" });
        }

        #endregion

    }
}
