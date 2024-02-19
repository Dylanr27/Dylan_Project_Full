using Microsoft.AspNetCore.Mvc;
using PetAdoption.Models;
using System.Diagnostics;

namespace PetAdoptionMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
