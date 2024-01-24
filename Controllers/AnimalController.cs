﻿using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;

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
    }
}
